﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Novacode;
using TranslatorHelper.Properties;

namespace TranslatorHelper
{
  using System.Text;

  public partial class FormMain : Form
  {
    public FormMain()
    {
      InitializeComponent();
    }

    private const string Backslash = "\\";
    private const string Period = ".";
    private bool sourceFileIsSmall = true; // thus load the source file in memory and working in memory

    private const string SourceDictionaryfileName = "MainDico.txt";

    private Dictionary<string, string> sourceDictionary;

    private void QuitToolStripMenuItemClick(object sender, EventArgs e)
    {
      Application.Exit();
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
      sourceDictionary = new Dictionary<string, string>();
      // loading dictionary
      if (sourceFileIsSmall)
      {
        if (!File.Exists(SourceDictionaryfileName))
        {
          using (StreamWriter sw = new StreamWriter(SourceDictionaryfileName, false, Encoding.UTF8))
          {
            // do nothing just create a new file
            sourceDictionary = new Dictionary<string, string>();
          }
        }
        else
        {
          // reading dictionary
          sourceDictionary = new Dictionary<string, string>();
          StreamReader sr = new StreamReader(SourceDictionaryfileName);
          bool readingEnglishLine = true;
          string line1 = string.Empty;
          string line2 = string.Empty;
          while (sr.Peek() >= 0)
          {
            string tmp = sr.ReadLine();
            if (readingEnglishLine)
            {
              line1 = tmp;
              readingEnglishLine = false;
            }
            else
            {
              line2 = tmp;
              readingEnglishLine = true;
              sourceDictionary.Add(line1, line2);
            }
          }
        }
      }
    }

    private void DisplayTitle()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      Text += string.Format(" V{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
    }

    private void GetWindowValue()
    {
      Width = Settings.Default.WindowWidth;
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
      // first copy the file
      try
      {
        if (File.Exists(textBoxTranslatedFileName.Text))
        {
          const string Message = "The translated file already exists, do you want to overwrite it?";
          const string Caption = "File already exists";
          const MessageBoxButtons Buttons = MessageBoxButtons.YesNo;
          DialogResult result = MessageBox.Show(this, Message, Caption, Buttons);
          if (result == DialogResult.Yes)
          {
            File.Delete(textBoxTranslatedFileName.Text);
            File.Copy(textBoxfilePath.Text, textBoxTranslatedFileName.Text);
          }
        }
        
      }
      catch (Exception exception)
      {
        MessageBox.Show("Error while copying the source file: " + exception.Message);
        return;
      }

      MessageBox.Show("end of operation");
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

    private void ButtonCountParagraphClick(object sender, EventArgs e)
    {
      string filename = string.Empty;
      DialogResult result = openFileDialog1.ShowDialog();
      if (result == DialogResult.OK)
      {
        filename = openFileDialog1.FileName;
      }
      else
      {
        MessageBox.Show("No file selected!");
        return;
      }

      using (DocX document = DocX.Load(filename))
      {
        int i = document.Paragraphs.Count;
        MessageBox.Show(string.Format("{0} has {1} paragraphs", filename, i));
      }
    }

    private static void ReplaceStrings(string filename)
    {
      using (DocX document = DocX.Load(filename))
      {
        //lineBreaks = document.FindUniqueByPattern(Environment.NewLine, RegexOptions.None);
        List<string> lineBreaks = document.FindUniqueByPattern("\r", RegexOptions.None);
        if (lineBreaks.Count > 0)
        {
          foreach (string s in lineBreaks)
          {
            document.ReplaceText(s, "boo!");
          }
        }

        document.Save();
      }
    }

    private static void ReplaceLineBreaksWithBoo(string filename)
    {
      using (DocX document = DocX.Load(filename))
      {
        //lineBreaks = document.FindUniqueByPattern(Environment.NewLine, RegexOptions.None);
        List<string> lineBreaks = document.FindUniqueByPattern("\r", RegexOptions.None);
        if (lineBreaks.Count > 0)
        {
          foreach (string s in lineBreaks)
          {
            document.ReplaceText(s, "boo!");
          }
        }

        document.Save();
      }
    }

    private void ButtonAddToDictionaryClick(object sender, EventArgs e)
    {

    }

    private void ButtonWordsClick(object sender, EventArgs e)
    {
      string filename = string.Empty;
      DialogResult result = openFileDialog1.ShowDialog();
      if (result == DialogResult.OK)
      {
        filename = openFileDialog1.FileName;
      }
      else
      {
        MessageBox.Show("No file selected!");
        return;
      }

      using (DocX document = DocX.Load(filename))
      {
        int i = document.Paragraphs.Count;
        MessageBox.Show(string.Format("{0} has {1} paragraphs", filename, i));
      }
    }

    private void ButtonPickFrenchDocumentClick(object sender, EventArgs e)
    {
      var opendialog = new OpenFileDialog
                         {
                           Filter = @"Word Documents(*.docx)| *.docx"
                         };
      if (opendialog.ShowDialog() == DialogResult.OK)
      {
        textBoxFrenchDocument.Text = opendialog.FileName;
      }
    }

    private void ButtonPickEnglishDocumentClick(object sender, EventArgs e)
    {
      var opendialog = new OpenFileDialog
      {
        Filter = @"Word Documents(*.docx)| *.docx"
      };
      if (opendialog.ShowDialog() == DialogResult.OK)
      {
        textBoxEnglishDocument.Text = opendialog.FileName;
      }
    }
  }
}