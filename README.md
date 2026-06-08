# 💿 ISO Maker

A simple, clean Windows desktop app for packing any folder into an ISO image — no command-line tools, no bloat.

Built with **C# / WinForms** on **.NET 8**.


---

## ✨ Features

- **Browse & pick** any source folder in a single click
- **Auto-names** the ISO after the source folder
- **Choose output location** — drop the ISO wherever you want
- **Live progress bar** while the image is being built
- **Cancel mid-build** — partial files are automatically cleaned up
- **Overwrite protection** — asks before replacing an existing file
- Produces standard **ISO 9660 + Joliet** images, compatible with Windows, Linux, and macOS

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download) (for building from source)
- Windows 10 / 11

### Build & Run

```bash
git clone https://github.com/YOUR_USERNAME/iso-maker.git
cd iso-maker
dotnet run
```

### Publish a standalone `.exe`

```bash
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
```

The output exe will be in `bin\Release\net8.0-windows\win-x64\publish\`.

---

## 📦 Dependencies

| Package | Purpose |
|---|---|
| [DiscUtils.Iso9660](https://github.com/DiscUtils/DiscUtils) | Pure-.NET ISO 9660 / Joliet image writer |

Restored automatically via NuGet — no manual installation needed.

---

## 🗂️ Project Structure

```
├── Program.cs           # Entry point
├── Form1.cs             # Application logic
├── Form1.Designer.cs    # WinForms layout
├── Form1.resx           # Form resources
├── ISO Maker.csproj     # Project file
└── favicon.ico          # App icon
```

---

## 📋 How to Use

1. Click **Browse…** next to *Source Folder* and select the folder you want to pack
2. The ISO name is filled in automatically — edit it if you like
3. Click **Browse…** next to *Output* and pick where to save the ISO
4. Click **Create ISO** and watch the progress bar
5. Done — your `.iso` file is ready

---

## 📄 License

MIT — do whatever you want with it.
