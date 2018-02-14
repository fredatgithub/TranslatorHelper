using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Novacode;
using TranslatorHelper.Properties;
using System.Linq;
using System.Text;
using System.Globalization;
namespace TranslatorHelper
{
  public partial class FormMain : Form
  {
    public FormMain()
    {
      DictionaryHasChanged = false;
      InitializeComponent();
    }

    private const string Backslash = "\\";
    private const string Period = ".";
    private const bool SourceFileIsSmall = true; // thus load the source file in memory and working in memory
    private int _changeCount;

    private string _sourceDictionaryfileName = "MainDico.txt";

    private bool _dictionaryIsSorted;
    private Dictionary<string, string> _sourceDictionary;

    public bool DictionaryHasChanged { get; set; }


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
        Filter = Resources.FileWord2007Filter,
        Multiselect = false
      };

      if (ofd.ShowDialog(this) != DialogResult.OK)
      {
        return;
      }

      textBoxfilePath.Text = ofd.FileName;
      textBoxTranslatedFileName.Text = GetDirectoryFileNameAndExtension(ofd.FileName)[0] + Backslash
                                       + GetDirectoryFileNameAndExtension(ofd.FileName)[1]
                                       + textBoxSuffixeFileName.Text
                                       + GetDirectoryFileNameAndExtension(ofd.FileName)[2];
    }

    public static string[] GetDirectoryFileNameAndExtension(string filePath)
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
      progressBarTranslate.Visible = false;
      progressBarAutoLearning.Visible = false;
      _sourceDictionary = new Dictionary<string, string>();
      // loading dictionary
      if (SourceFileIsSmall)
      {
        if (!File.Exists(_sourceDictionaryfileName))
        {
          using (StreamWriter sw = new StreamWriter(_sourceDictionaryfileName, false, Encoding.UTF8))
          {
            // do nothing just create a new file
            _sourceDictionary = new Dictionary<string, string>();
          }
        }
        else
        {
          // reading dictionary
          // the file must not have empty line
          RemoveEmptyLine(_sourceDictionaryfileName);
          _sourceDictionary = new Dictionary<string, string>();
          StreamReader sr = new StreamReader(_sourceDictionaryfileName);
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
              if (!_sourceDictionary.ContainsKey(line1) && !_sourceDictionary.ContainsValue(line2))
              {
                _sourceDictionary.Add(line1, line2);
              }
            }
          }

          LoadDictionaryIntoListBoxes();
          DictionaryHasChanged = false;
        }
      }
    }

    private static void RemoveEmptyLine(string dictionaryFileName)
    {
      // removing empty line
      if (!File.Exists(dictionaryFileName))
      {
        return;
      }

      List<string> newFile = new List<string>();
      StreamReader sr = new StreamReader(dictionaryFileName);
      while (sr.Peek() >= 0)
      {
        string newLine = sr.ReadLine();
        if (newLine != string.Empty)
        {
          newFile.Add(newLine);
        }
      }

      sr.Close();
      // instead of delete the old file, we keep it and rename it to check that everything is ok
      //File.Replace(dictionaryFileName, dictionaryFileName, dictionaryFileName + "_backup");
      if (File.Exists(dictionaryFileName + ".backup.txt"))
      {
        File.Delete(dictionaryFileName + ".backup.txt");
      }

      File.Copy(dictionaryFileName, dictionaryFileName + ".backup.txt", true);
      File.Delete(dictionaryFileName);
      StreamWriter sw = new StreamWriter(dictionaryFileName);
      foreach (string line in newFile)
      {
        sw.WriteLine(line);
      }

      sw.Close();
    }

    private void LoadDictionaryIntoListBoxes()
    {
      // loading dictionary into edit textboxes
      listBoxEditFrench.Items.Clear();
      listBoxEditEnglish.Items.Clear();
      int countLines = 0;
      foreach (KeyValuePair<string, string> dicoEntry in _sourceDictionary)
      {
        listBoxEditFrench.Items.Add(dicoEntry.Key);
        listBoxEditEnglish.Items.Add(dicoEntry.Value);
        countLines++;
      }

      labelEditFrench.Text = Resources.French + countLines + Resources.entry + PluralWithWordChange(countLines, "eng") + Resources.closingParenthesis;
      labelEditEnglish.Text = Resources.English + countLines + Resources.entry + PluralWithWordChange(countLines, "eng") + Resources.closingParenthesis;
    }

    private void DisplayTitle()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      Text += string.Format("V{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
    }

    public static string GetApplicationTitle()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      return string.Format(" V{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
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

    private DialogResult DisplayMessage(string message, string title, MessageBoxButtons buttons)
    {
      DialogResult result = MessageBox.Show(this, message, title, buttons);
      return result;
    }

    public static string StripZeroTime(string theTimeToStripped)
    {
      string result = theTimeToStripped;
      for (int i = 1; i < 4; i++)
      {
        if (result.StartsWith("00"))
        {
          result = result.Substring(4);
        }
        else
        {
          break;
        }
      }

      return result;
    }

    public static string ToHourMinuteSecond(long millisecs)
    {
      TimeSpan t = TimeSpan.FromMilliseconds(millisecs);

      string result = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                t.Hours,
                t.Minutes,
                t.Seconds,
                t.Milliseconds);
      return result;
    }

    private void ButtonConvertClick(object sender, EventArgs e)
    {
      //comptage des changements
      _changeCount = 0;
      progressBarTranslate.Visible = true;
      // first copy the file
      try
      {
        if (File.Exists(textBoxTranslatedFileName.Text))
        {
          const string message = "The translated file already exists, do you want to overwrite it?";
          const string caption = "File already exists";
          const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
          DialogResult result = MessageBox.Show(this, message, caption, buttons);
          if (result == DialogResult.Yes)
          {
            File.Copy(textBoxTranslatedFileName.Text, IncreaseFileName(textBoxTranslatedFileName.Text + ".backup.txt")); // add a number if file already exist by method
            File.Delete(textBoxTranslatedFileName.Text);
            File.Copy(textBoxfilePath.Text, textBoxTranslatedFileName.Text);
          }
        }
        else
        {
          File.Copy(textBoxfilePath.Text, textBoxTranslatedFileName.Text);
        }

      }
      catch (Exception exception)
      {
        MessageBox.Show(Resources.ErrorWhileCopying + exception.Message);
        return;
      }

      // remove empty line and sort dictionary
      Stopwatch chrono = new Stopwatch();
      chrono.Start();
      progressBarTranslate.Minimum = 1;
      progressBarTranslate.Maximum = _sourceDictionary.Count;
      progressBarTranslate.Value = progressBarTranslate.Minimum;
      int compteur = progressBarTranslate.Minimum;
      foreach (KeyValuePair<string, string> dictionaryEntry in _sourceDictionary)
      {
        ReplaceStrings(textBoxTranslatedFileName.Text, dictionaryEntry.Key, dictionaryEntry.Value);
        progressBarTranslate.Value = compteur;
        compteur++;
      }

      progressBarTranslate.Value = progressBarTranslate.Minimum;
      progressBarTranslate.Visible = false;
      chrono.Stop();
      long duration = chrono.ElapsedMilliseconds;
      string timeElapse = StripZeroTime(ToHourMinuteSecond(duration));
      MessageBox.Show(string.Format("End of translation operation\n{0} change{1} have been made\nIt took {2}", _changeCount, Plural(_changeCount), timeElapse));
      const string dialogMessage = "Do you want to open the newly translated document ?";
      const string dialogCaption = "Open translated document";
      const MessageBoxButtons myBoxButtons = MessageBoxButtons.YesNo;
      DialogResult dialogResult = MessageBox.Show(this, dialogMessage, dialogCaption, myBoxButtons);
      if (dialogResult == DialogResult.Yes)
      {
        try
        {
          Process.Start(textBoxTranslatedFileName.Text);
        }
        catch (Exception exception)
        {
          MessageBox.Show(Resources.ErrorWhileOpening + textBoxTranslatedFileName.Text + Resources.CarriageReturn + exception.Message);
        }

      }
    }

    public static string Plural(int number)
    {
      return number > 1 ? "s" : string.Empty;
    }

    public static string PluralWithWordChange(int number, string language = "fr")
    {
      if (language.ToLower() == "eng")
      {
        return number > 1 ? "ies" : "y";
      }

      return number > 1 ? "s" : string.Empty;
    }

    public static string IncreaseFileName(string fileName)
    {
      int fileNumber = 1;
      string result = AddAtTheEndOfFileName(fileName, fileNumber.ToString(CultureInfo.InvariantCulture));
      while (File.Exists(result))
      {
        fileNumber++;
        result = AddAtTheEndOfFileName(fileName, fileNumber.ToString(CultureInfo.InvariantCulture));
      }

      return result;
    }

    public static string AddAtTheEndOfFileName(string fileName, string textToBeAdded)
    {
      string result = GetDirectoryFileNameAndExtension(fileName)[0] + Backslash
                                     + GetDirectoryFileNameAndExtension(fileName)[1]
                                   + textToBeAdded
                                 + GetDirectoryFileNameAndExtension(fileName)[2];
      return result;
    }

    private void FrenchToolStripMenuItemClick(object sender, EventArgs e)
    {
      MenuLanguageTo(Language.French);
    }

    private void MenuLanguageTo(Language language)
    {
      while (true)
      {
        switch (language)
        {
          case Language.French:
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
          case Language.English:
            frenchToolStripMenuItem.Checked = false;
            englishToolStripMenuItem.Checked = true;
            fileToolStripMenuItem.Text = Settings.Default.US_File;
            quitToolStripMenuItem.Text = Settings.Default.US_Quit;
            languageToolStripMenuItem.Text = Settings.Default.US_Language;
            frenchToolStripMenuItem.Text = Settings.Default.US_French;
            englishToolStripMenuItem.Text = Settings.Default.US_English;
            helpToolStripMenuItem.Text = Settings.Default.US_Help;
            aboutToolStripMenuItem.Text = Settings.Default.US_About;
            break;
          default:
            language = Language.English;
            continue;
        }
        break;
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
        MessageBox.Show(Resources.NoFileSelected);
        return;
      }

      using (DocX document = DocX.Load(filename))
      {
        int i = document.Paragraphs.Count;
        MessageBox.Show(string.Format("{0} has {1} paragraphs", filename, i));
      }
    }

    private void ReplaceStrings(string filename, string wordToFound, string wordtoBeReplaced)
    {
      using (DocX document = DocX.Load(filename))
      {
        if (wordToFound != string.Empty)
        {
          List<string> lineFound = document.FindUniqueByPattern(wordToFound, RegexOptions.None);
          if (lineFound.Count > 0)
          {
            foreach (string s in lineFound)
            {
              if (wordtoBeReplaced != string.Empty)
              {
                document.ReplaceText(s, wordtoBeReplaced);
                _changeCount++;
              }
            }
          }

          document.Save();
        }
      }
    }

    private static void ReplaceLineBreaksWithSomething(string filename)
    {
      using (DocX document = DocX.Load(filename))
      {
        //lineBreaks = document.FindUniqueByPattern(Environment.NewLine, RegexOptions.None);
        List<string> lineBreaks = document.FindUniqueByPattern("\r", RegexOptions.None);
        if (lineBreaks.Count > 0)
        {
          foreach (string s in lineBreaks)
          {
            document.ReplaceText(s, "someText");
          }
        }

        document.Save();
      }
    }

    private void ButtonAddToDictionaryClick(object sender, EventArgs e)
    {
      if (textBoxInputFrench.Text == string.Empty || textBoxInputEnglish.Text == string.Empty)
      {
        MessageBox.Show(Resources.NoEmptyTextBox);
        return;
      }

      try
      {
        StreamWriter sw = new StreamWriter(_sourceDictionaryfileName);
        sw.WriteLine(textBoxInputFrench.Text);
        sw.WriteLine(textBoxInputEnglish.Text);
        sw.Close();
      }
      catch (Exception exception)
      {
        MessageBox.Show(Resources.ErrorWhileSavingToDictionary + exception.Message);
      }
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
        MessageBox.Show(Resources.NoFileSelected);
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
        listBoxAutoLearningFrench.Items.Clear();
        DocxToText dtt = new DocxToText(opendialog.FileName);
        string text = dtt.ExtractText();
        string[] tmpPhrases = ConvertTextToArray(text);
        for (int i = 0; i < ConvertTextToArray(text).Length - 1; i++)
        {
          if (tmpPhrases[i] != "\r")
          {
            listBoxAutoLearningFrench.Items.Add(tmpPhrases[i]);
          }
        }
      }
    }

    public static string[] ConvertTextToArray(string chaine)
    {
      return chaine.Split('\n');
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
        listBoxAutoLearningEnglish.Items.Clear();
        DocxToText dtt = new DocxToText(opendialog.FileName);
        string text = dtt.ExtractText();
        string[] tmpPhrases = ConvertTextToArray(text);
        for (int i = 0; i < ConvertTextToArray(text).Length - 1; i++)
        {
          if (tmpPhrases[i] != "\r")
          {
            listBoxAutoLearningEnglish.Items.Add(tmpPhrases[i]);
          }
        }
      }
    }

    private void ButtonEditDictionaryClick(object sender, EventArgs e)
    {
      //copy to previous tab selected item
      if (listBoxEditFrench.SelectedIndex == -1)
      {
        MessageBox.Show(Resources.PleaseSelectOneWord);
        return;
      }

      textBoxInputFrench.Text = listBoxEditFrench.SelectedItem.ToString();
      textBoxInputEnglish.Text = listBoxEditEnglish.SelectedItem.ToString();
      tabControl1.SelectedIndex = 1;
    }

    private void ListBoxEditFrenchSelectedIndexChanged(object sender, EventArgs e)
    {
      listBoxEditEnglish.SelectedIndex = listBoxEditFrench.SelectedIndex;
    }

    private void ListBoxEditEnglishSelectedIndexChanged(object sender, EventArgs e)
    {
      listBoxEditFrench.SelectedIndex = listBoxEditEnglish.SelectedIndex;
    }

    private void ButtonSortDictionaryClick(object sender, EventArgs e)
    {
      // sorting the dictionary from the bigest to the smallest phrase
      _sourceDictionary = SortDictionaryByLength(_sourceDictionary);
      _dictionaryIsSorted = true;
      DictionaryHasChanged = true;
      MessageBox.Show(Resources.DictionaryIsSorted);
      LoadDictionaryIntoListBoxes();
      tabControl1.SelectedIndex = 2;
    }

    public static Dictionary<string, string> SortDictionaryByLength(Dictionary<string, string> unsortedDictionary)
    {
      var queryResults = (from kp in unsortedDictionary orderby kp.Key.Length descending select new KeyValuePair<string, string>(kp.Key, kp.Value));
      return queryResults.ToDictionary(x => x.Key, x => x.Value);
    }

    private void TabControl1Selected(object sender, TabControlEventArgs e)
    {
      if (e.TabPage == tabPageTool)
      {
        textBoxCurrentDictionary.Text = _sourceDictionaryfileName;
      }
    }

    private void ButtonReloadDictionaryClick(object sender, EventArgs e)
    {
      LoadDictionaryIntoListBoxes();
    }

    private void ButtonRemoveDuplicateFrenchClick(object sender, EventArgs e)
    {
      //removing duplicate in listbox french
      listBoxAutoLearningFrench.Sorted = true;
      //for (int i = listBoxAutoLearningFrench.Items.Count - 1; i > 0; i--)
      //{
      //  if (listBoxAutoLearningFrench.Items[i] == listBoxAutoLearningFrench.Items[i - 1])
      //  {
      //    listBoxAutoLearningFrench.Items.Remove(listBoxAutoLearningFrench.Items[i - 1]);
      //  }
      //}

      // listbox.Items = listbox.Items.Select(n => !n.Contains("OBJECT"));
      //listBoxAutoLearningFrench.Items = listBoxAutoLearningFrench.Items.Select(n => n.Distinct());
    }

    private void ButtonRemoveDuplicateInDictionaryClick(object sender, EventArgs e)
    {
      DictionaryHasChanged = true;
    }

    private void ListBoxAutoLearningFrenchSelectedIndexChanged(object sender, EventArgs e)
    {
      listBoxAutoLearningEnglish.SelectedIndex = listBoxAutoLearningFrench.SelectedIndex;
    }

    private void ListBoxAutoLearningEnglishSelectedIndexChanged(object sender, EventArgs e)
    {
      listBoxAutoLearningFrench.SelectedIndex = listBoxAutoLearningEnglish.SelectedIndex;
    }

    private void ButtonPickAutoLearningDirectoryClick(object sender, EventArgs e)
    {
      if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
      {
        textBoxAutoDirectory.Text = folderBrowserDialog1.SelectedPath;
      }
    }

    private void ButtonLiveLearningPickFrenchDocClick(object sender, EventArgs e)
    {
      var opendialog = new OpenFileDialog
      {
        Filter = @"Word Documents(*.docx)| *.docx"
      };

      if (opendialog.ShowDialog() == DialogResult.OK)
      {
        textBoxLiveLearningFrenchDocPath.Text = opendialog.FileName;
        listBoxLiveLearningFrenchSentences.Items.Clear();
        textBoxLiveLearningEnglishTranslation.Text = string.Empty;
        listBoxLiveLearningFrDocNotTranslated.Items.Clear();
        DocxToText dtt = new DocxToText(opendialog.FileName);
        string text = dtt.ExtractText();
        string[] tmpPhrases = ConvertTextToArray(text);
        for (int i = 0; i < ConvertTextToArray(text).Length - 1; i++)
        {
          if (tmpPhrases[i] != "\r")
          {
            listBoxLiveLearningFrenchSentences.Items.Add(tmpPhrases[i]);
          }
        }
      }
    }

    private void ButtonLiveLearningAddToDictionaryClick(object sender, EventArgs e)
    {
      if (listBoxLiveLearningFrDocNotTranslated.SelectedIndex == -1)
      {
        MessageBox.Show(Resources.SelectFrenchSentence);
        return;
      }

      if (textBoxLiveLearningEnglishTranslation.Text == string.Empty)
      {
        MessageBox.Show(Resources.TypeInText);
        return;
      }

      // adding to the main dictionary
    }

    private void ButtonDictionaryIntegrityCheckClick(object sender, EventArgs e)
    {
      // check if dictionary has an even number of lines, has blank lines
      int counter = 0;
      bool hasBlankLines = false;
      bool hadEvenLines = false;
    }

    private void NewToolStripMenuItemClick(object sender, EventArgs e)
    {
      if (DictionaryHasChanged)
      {
        // ask if user wants to save it
        const string message = "The dictionary has changed\nDo you want to save it?";
        const string caption = "Dictionary has changed";
        const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        DialogResult result = MessageBox.Show(this, message, caption, buttons);
        if (result == DialogResult.Yes)
        {
          DictionarySave();
        }
      }
      else
      {
        // ask user if he wants to backup the dictionary
        const string message = "Do you want to backup the dictionary ?";
        const string caption = "Backup the dictionary";
        const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        DialogResult result = MessageBox.Show(this, message, caption, buttons);
        if (result == DialogResult.Yes)
        {
          BackupDictionary();
        }
      }
    }

    private void BackupDictionary()
    {
      File.Copy(_sourceDictionaryfileName, IncreaseFileName(_sourceDictionaryfileName), false);
    }

    private void DictionarySave()
    {
      if (File.Exists(_sourceDictionaryfileName))
      {
        File.Delete(_sourceDictionaryfileName);
      }

      StreamWriter sw = new StreamWriter(_sourceDictionaryfileName);
      foreach (KeyValuePair<string, string> dicoEntry in _sourceDictionary)
      {
        sw.WriteLine(dicoEntry.Key);
        sw.WriteLine(dicoEntry.Value);
      }

      sw.Close();
      DictionaryHasChanged = false;
    }

    private void SaveToolStripMenuItemClick(object sender, EventArgs e)
    {
      DictionarySave();
    }

    private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
    {
      // ask user what name to assign to new file with SavedialogBox
    }

    private void OpenToolStripMenuItemClick(object sender, EventArgs e)
    {
      if (DictionaryHasChanged)
      {
        // ask if user wants to save it
        const string message = "The dictionary has changed\nDo you want to save it?";
        const string caption = "Dictionary has changed";
        const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        DialogResult result = MessageBox.Show(this, message, caption, buttons);
        if (result == DialogResult.Yes)
        {
          DictionarySave();
        }
      }
      else
      {
        OpenFileDialog ofd = new OpenFileDialog
        {
          //InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
          Filter = Resources.TextFilesFilter, Multiselect = false
        };

        if (ofd.ShowDialog(this) != DialogResult.OK)
        {
          return;
        }

        _sourceDictionaryfileName = ofd.FileName;
        _sourceDictionary = new Dictionary<string, string>();
        StreamReader sr = new StreamReader(_sourceDictionaryfileName);
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
            if (!_sourceDictionary.ContainsKey(line1) && !_sourceDictionary.ContainsValue(line2))
            {
              _sourceDictionary.Add(line1, line2);
            }
          }
        }

        LoadDictionaryIntoListBoxes();
        DictionaryHasChanged = false;
      }
    }
  }
}
