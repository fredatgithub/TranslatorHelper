using System;
using System.Windows.Forms;
using Novacode;


namespace TranslatorHelper
{
  using System.Diagnostics;
  using System.IO;
  using System.Reflection;

  using TranslatorHelper.Properties;

  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private const string Backslash = "\\";
    private const string Period = ".";

    private void QuitToolStripMenuItemClick(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void TabPageMainClick(object sender, EventArgs e)
    {

    }

    private void ButtonChooseFileClick(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog
                             {
                               InitialDirectory =
                                 Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                               Filter = "Fichiers Word 2007-2010 (*.docx)|*.docx",
                               Multiselect = false
                             };

      if (ofd.ShowDialog(this) != DialogResult.OK)
      {
        return;
      }

      this.textBoxfilePath.Text = ofd.FileName;
      this.textBoxTranslatedFileName.Text = GetDirectoryFileNameAndExtension(ofd.FileName)[0] + Backslash
                                       + GetDirectoryFileNameAndExtension(ofd.FileName)[1]
                                       + this.textBoxSuffixeFileName.Text
                                       + GetDirectoryFileNameAndExtension(ofd.FileName)[2];
    }

    private static string[] GetDirectoryFileNameAndExtension(string filePath)
    {
      string directory = Path.GetDirectoryName(filePath);
      string fileName = Path.GetFileNameWithoutExtension(filePath);
      string extension = Path.GetExtension(filePath);

      return new[] { directory, fileName, extension };
    }

    private void AboutToolStripMenuItemClick(object sender, EventArgs e)
    {
      AboutTheApplication aboutTheApplication = new AboutTheApplication();
      aboutTheApplication.ShowDialog();
    }

    private void FormMainLoad(object sender, EventArgs e)
    {
      DisplayTitle();
      GetWindowValue();
    }

    private void DisplayTitle()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      Text += string.Format(" V{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
    }

    private void GetWindowValue()
    {
      // Set this if you want a minimum width
      //Width = Settings.Default.WindowWidth < 395 ? 395 : Settings.Default.WindowWidth;
      Width = Settings.Default.WindowWidth;
      // Set this if you want a minimum Height
      // Height = Settings.Default.WindowHeight < 180 ? 180 : Settings.Default.WindowHeight;
      Height = Settings.Default.WindowHeight;
      Top = Settings.Default.WindowTop < 0 ? 0 : Settings.Default.WindowTop;
      Left = Settings.Default.WindowLeft < 0 ? 0 : Settings.Default.WindowLeft;
    }

    private void SaveWindowValue()
    {
      Settings.Default.WindowHeight = Height;
      Settings.Default.WindowWidth = Width;
      Settings.Default.WindowLeft = Left;
      Settings.Default.WindowTop = Top;
      Settings.Default.Save();
    }

    private void FormMainFormClosing(object sender, FormClosingEventArgs e)
    {
      SaveWindowValue();
    }

    private void ButtonConvertClick(object sender, EventArgs e)
    {

    }

    private void FrenchToolStripMenuItemClick(object sender, EventArgs e)
    {
      MenuLanguageTo(Language.French);
    }

    private void MenuLanguageTo(Language language)
    {
      if (language == Language.French)
      {
        frenchToolStripMenuItem.Checked = true;
        englishToolStripMenuItem.Checked = false;
        fileToolStripMenuItem.Text = Settings.Default.FR_File;
        quitToolStripMenuItem.Text = Settings.Default.FR_Quit;
        languageToolStripMenuItem.Text = Settings.Default.FR_Language;
        frenchToolStripMenuItem.Text = Settings.Default.FR_French;
        englishToolStripMenuItem.Text = Settings.Default.FR_English;
        helpToolStripMenuItem.Text = Settings.Default.FR_Help;
        aboutToolStripMenuItem.Text = Settings.Default.FR_About;

        return;
      }

      if (language == Language.English)
      {
        frenchToolStripMenuItem.Checked = false;
        englishToolStripMenuItem.Checked = true;
        fileToolStripMenuItem.Text = Settings.Default.US_File;
        quitToolStripMenuItem.Text = Settings.Default.US_Quit;
        languageToolStripMenuItem.Text = Settings.Default.US_Language;
        frenchToolStripMenuItem.Text = Settings.Default.US_French;
        englishToolStripMenuItem.Text = Settings.Default.US_English;
        helpToolStripMenuItem.Text = Settings.Default.US_Help;
        aboutToolStripMenuItem.Text = Settings.Default.US_About;
      }
    }

    private void EnglishToolStripMenuItemClick(object sender, EventArgs e)
    {
      MenuLanguageTo(Language.English);
    }

  }
}