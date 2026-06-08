using DiscUtils.Iso9660;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IsoMaker
{
    public partial class Form1 : Form
    {
        private string _sourceDir = string.Empty;
        private string _outputDir = string.Empty;
        private CancellationTokenSource? _cts;

        public Form1()
        {
            InitializeComponent();
        }

        // ── Browse source directory ──────────────────────────────────────────
        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog
            {
                Description = "Select the folder to pack into an ISO",
                UseDescriptionForTitle = true,
                ShowNewFolderButton = false
            };

            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            _sourceDir = dlg.SelectedPath;
            txtSourceDir.Text = _sourceDir;

            // Auto-fill ISO name from directory name
            string dirName = Path.GetFileName(_sourceDir);
            txtIsoName.Text = SanitizeFilename(dirName) + ".iso";

            UpdateReadiness();
        }

        // ── Browse output directory ──────────────────────────────────────────
        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog
            {
                Description = "Select where to save the ISO file",
                UseDescriptionForTitle = true,
                ShowNewFolderButton = true
            };

            if (!string.IsNullOrEmpty(_outputDir))
                dlg.InitialDirectory = _outputDir;

            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            _outputDir = dlg.SelectedPath;
            txtOutputDir.Text = _outputDir;

            UpdateReadiness();
        }

        // ── Create ISO ───────────────────────────────────────────────────────
        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            string isoPath = Path.Combine(_outputDir, txtIsoName.Text.Trim());

            if (File.Exists(isoPath))
            {
                var result = MessageBox.Show(
                    $"'{txtIsoName.Text.Trim()}' already exists in the output folder.\nOverwrite it?",
                    "File Exists",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes) return;
            }

            SetBusy(true);
            progressBar.Value = 0;
            lblStatus.Text = "Scanning files…";

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            var progress = new Progress<(int percent, string message)>(report =>
            {
                progressBar.Value = report.percent;
                lblStatus.Text = report.message;
            });

            try
            {
                await System.Threading.Tasks.Task.Run(
                    () => BuildIso(_sourceDir, isoPath, progress, token),
                    token);

                lblStatus.Text = "Done!";
                progressBar.Value = 100;

                MessageBox.Show(
                    $"ISO created successfully:\n{isoPath}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "Cancelled.";
                progressBar.Value = 0;
                TryDelete(isoPath);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error.";
                TryDelete(isoPath);
                MessageBox.Show(
                    $"Failed to create ISO:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                SetBusy(false);
                _cts?.Dispose();
                _cts = null;
            }
        }

        // ── Cancel ───────────────────────────────────────────────────────────
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }

        // ── Core ISO builder (runs on background thread) ─────────────────────
        private static void BuildIso(
            string sourceDir,
            string isoPath,
            IProgress<(int, string)> progress,
            CancellationToken ct)
        {
            // Enumerate all files
            var allFiles = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories);
            int total = allFiles.Length;
            if (total == 0) throw new InvalidOperationException("The selected folder contains no files.");

            var builder = new CDBuilder
            {
                UseJoliet = true,
                VolumeIdentifier = Path.GetFileNameWithoutExtension(isoPath)
                                       .ToUpperInvariant()
                                       .Replace(" ", "_")
                                       .Substring(0, Math.Min(32,
                                           Path.GetFileNameWithoutExtension(isoPath).Length))
            };

            int done = 0;
            foreach (string filePath in allFiles)
            {
                ct.ThrowIfCancellationRequested();

                // Build the in-ISO path relative to the source root
                string relative = Path.GetRelativePath(sourceDir, filePath);
                // ISO uses backslash on DiscUtils
                string isoRelative = relative.Replace(Path.DirectorySeparatorChar, '\\');

                builder.AddFile(isoRelative, filePath);

                done++;
                int percent = (int)((done / (double)total) * 90); // reserve last 10% for write
                progress.Report((percent, $"Adding file {done} of {total}: {Path.GetFileName(filePath)}"));
            }

            progress.Report((91, "Writing ISO image…"));
            builder.Build(isoPath);
            progress.Report((100, "Done!"));
        }

        // ── Helpers ──────────────────────────────────────────────────────────
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(_sourceDir) || !Directory.Exists(_sourceDir))
            {
                MessageBox.Show("Please select a valid source folder.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(_outputDir) || !Directory.Exists(_outputDir))
            {
                MessageBox.Show("Please select a valid output folder.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string name = txtIsoName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("ISO file name cannot be empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                MessageBox.Show("ISO file name contains invalid characters.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!name.EndsWith(".iso", StringComparison.OrdinalIgnoreCase))
                txtIsoName.Text = name + ".iso";

            return true;
        }

        private void UpdateReadiness()
        {
            btnCreate.Enabled =
                !string.IsNullOrWhiteSpace(_sourceDir) &&
                !string.IsNullOrWhiteSpace(_outputDir);
        }

        private void SetBusy(bool busy)
        {
            btnCreate.Enabled = !busy;
            btnCancel.Enabled = busy;
            btnBrowseSource.Enabled = !busy;
            btnBrowseOutput.Enabled = !busy;
            txtSourceDir.Enabled = !busy;
            txtOutputDir.Enabled = !busy;
            txtIsoName.Enabled = !busy;
            progressBar.Style = busy ? ProgressBarStyle.Continuous : ProgressBarStyle.Continuous;
        }

        private static string SanitizeFilename(string name)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return string.IsNullOrWhiteSpace(name) ? "output" : name;
        }

        private static void TryDelete(string path)
        {
            try { if (File.Exists(path)) File.Delete(path); } catch { /* ignore */ }
        }
    }
}