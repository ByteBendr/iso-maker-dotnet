namespace IsoMaker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            grpSource = new GroupBox();
            txtSourceDir = new TextBox();
            btnBrowseSource = new Button();
            grpOutput = new GroupBox();
            txtOutputDir = new TextBox();
            btnBrowseOutput = new Button();
            lblIsoName = new Label();
            txtIsoName = new TextBox();
            grpProgress = new GroupBox();
            progressBar = new ProgressBar();
            lblStatus = new Label();
            pnlButtons = new Panel();
            btnCreate = new Button();
            btnCancel = new Button();
            grpSource.SuspendLayout();
            grpOutput.SuspendLayout();
            grpProgress.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // grpSource
            // 
            grpSource.Controls.Add(txtSourceDir);
            grpSource.Controls.Add(btnBrowseSource);
            grpSource.Location = new Point(12, 12);
            grpSource.Name = "grpSource";
            grpSource.Size = new Size(560, 60);
            grpSource.TabIndex = 0;
            grpSource.TabStop = false;
            grpSource.Text = "Source Folder";
            // 
            // txtSourceDir
            // 
            txtSourceDir.Location = new Point(10, 24);
            txtSourceDir.Name = "txtSourceDir";
            txtSourceDir.PlaceholderText = "Choose the folder you want to pack…";
            txtSourceDir.ReadOnly = true;
            txtSourceDir.Size = new Size(454, 23);
            txtSourceDir.TabIndex = 0;
            // 
            // btnBrowseSource
            // 
            btnBrowseSource.Location = new Point(470, 23);
            btnBrowseSource.Name = "btnBrowseSource";
            btnBrowseSource.Size = new Size(78, 25);
            btnBrowseSource.TabIndex = 1;
            btnBrowseSource.Text = "Browse…";
            btnBrowseSource.Click += btnBrowseSource_Click;
            // 
            // grpOutput
            // 
            grpOutput.Controls.Add(txtOutputDir);
            grpOutput.Controls.Add(btnBrowseOutput);
            grpOutput.Controls.Add(lblIsoName);
            grpOutput.Controls.Add(txtIsoName);
            grpOutput.Location = new Point(12, 82);
            grpOutput.Name = "grpOutput";
            grpOutput.Size = new Size(560, 96);
            grpOutput.TabIndex = 1;
            grpOutput.TabStop = false;
            grpOutput.Text = "Output";
            // 
            // txtOutputDir
            // 
            txtOutputDir.Location = new Point(10, 24);
            txtOutputDir.Name = "txtOutputDir";
            txtOutputDir.PlaceholderText = "Choose where to save the ISO…";
            txtOutputDir.ReadOnly = true;
            txtOutputDir.Size = new Size(454, 23);
            txtOutputDir.TabIndex = 2;
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Location = new Point(470, 23);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new Size(78, 25);
            btnBrowseOutput.TabIndex = 3;
            btnBrowseOutput.Text = "Browse…";
            btnBrowseOutput.Click += btnBrowseOutput_Click;
            // 
            // lblIsoName
            // 
            lblIsoName.Location = new Point(10, 58);
            lblIsoName.Name = "lblIsoName";
            lblIsoName.Size = new Size(88, 23);
            lblIsoName.TabIndex = 4;
            lblIsoName.Text = "ISO file name:";
            lblIsoName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtIsoName
            // 
            txtIsoName.Location = new Point(102, 57);
            txtIsoName.Name = "txtIsoName";
            txtIsoName.Size = new Size(446, 23);
            txtIsoName.TabIndex = 4;
            // 
            // grpProgress
            // 
            grpProgress.Controls.Add(progressBar);
            grpProgress.Controls.Add(lblStatus);
            grpProgress.Location = new Point(12, 188);
            grpProgress.Name = "grpProgress";
            grpProgress.Size = new Size(560, 68);
            grpProgress.TabIndex = 2;
            grpProgress.TabStop = false;
            grpProgress.Text = "Progress";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(10, 22);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(540, 20);
            progressBar.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = SystemColors.GrayText;
            lblStatus.Location = new Point(10, 46);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(540, 16);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Ready.";
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnCreate);
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Location = new Point(12, 264);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(560, 36);
            pnlButtons.TabIndex = 3;
            // 
            // btnCreate
            // 
            btnCreate.Enabled = false;
            btnCreate.Location = new Point(370, 4);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(90, 28);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create ISO";
            btnCreate.Click += btnCreate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(466, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 28);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 311);
            Controls.Add(grpSource);
            Controls.Add(grpOutput);
            Controls.Add(grpProgress);
            Controls.Add(pnlButtons);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "ISO Maker";
            grpSource.ResumeLayout(false);
            grpSource.PerformLayout();
            grpOutput.ResumeLayout(false);
            grpOutput.PerformLayout();
            grpProgress.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.TextBox txtSourceDir;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Label lblIsoName;
        private System.Windows.Forms.TextBox txtIsoName;
        private System.Windows.Forms.GroupBox grpProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
    }
}