using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatorHelper;

namespace UnitTestTranslatorHelper
{
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.IO;
  using System.Reflection;

  [TestClass]
  public class UnitTestStaticMethod
  {
    [TestMethod]
    public void TestStripZeroTime()
    {
      Assert.AreEqual("01h:01m:17s:000ms", FormMain.StripZeroTime("01h:01m:17s:000ms"));
      Assert.AreEqual("01m:17s:000ms", FormMain.StripZeroTime("00h:01m:17s:000ms"));
      Assert.AreEqual("17s:000ms", FormMain.StripZeroTime("00h:00m:17s:000ms"));
      Assert.AreEqual("900ms", FormMain.StripZeroTime("00h:00m:00s:900ms"));
      Assert.AreEqual("000ms", FormMain.StripZeroTime("00h:00m:00s:000ms"));
    }

    [TestMethod]
    public void TestToHourMinuteSecond()
    {
      Assert.AreEqual("00h:00m:19s:000ms", FormMain.ToHourMinuteSecond(19));
      Assert.AreEqual("00h:01m:00s:000ms", FormMain.ToHourMinuteSecond(60));
      Assert.AreEqual("01h:00m:00s:000ms", FormMain.ToHourMinuteSecond(3600));
      Assert.AreEqual("00h:00m:00s:000ms", FormMain.ToHourMinuteSecond(0));
    }

    [TestMethod]
    public void TestSortDictionaryByLength()
    {
      Dictionary<string, string> unsortedDictionary = new Dictionary<string, string>();
      unsortedDictionary.Add("test", "test");
      unsortedDictionary.Add("problème", "problem");
      unsortedDictionary.Add("ceci est un test", "this is a test");

      Dictionary<string, string> sortedDictionary = new Dictionary<string, string>();
      sortedDictionary.Add("ceci est un test", "this is a test");
      sortedDictionary.Add("problème", "problem");
      sortedDictionary.Add("test", "test");
      
      //Assert.AreEqual(FormMain.SortDictionaryByLength(unsortedDictionary),
        //              FormMain.SortDictionaryByLength(unsortedDictionary));
      Dictionary<string, string> result1 = new Dictionary<string, string>();
      result1 = FormMain.SortDictionaryByLength(unsortedDictionary);
      Dictionary<string, string> result2 = new Dictionary<string, string>();
      result2 = sortedDictionary;
      
      string[] dico1 = new string[result1.Count];
      string[] dico2 = new string[result2.Count];
      int compteur = 0;
      foreach (KeyValuePair<string, string> entry in result1)
      {
        dico1[compteur] = entry.Value;
        compteur++;
      }

      compteur = 0;
      foreach (KeyValuePair<string, string> entry in result2)
      {
        dico2[compteur] = entry.Value;
        compteur++;
      }

      for (int i = 0; i < dico1.Length; i++)
      {
        Assert.AreEqual(dico1[i], dico2[i]);
      }
    }

    [TestMethod]
    public void TestConvertTextToArray()
    {
      string[] result1 = { "1", "2", "3", "4"};
      string[] result2 = FormMain.ConvertTextToArray("1\n2\n3\n4");
      for (int i = 0; i < result2.Length; i++)
      {
        Assert.AreEqual(result1[i], result2[i]);
      }
      
    }

    [TestMethod]
    public void TestAddAtTheEndOfFileName()
    {
      const string filePath = "C:\\program files\\software\\application1.txt";
      const string textToBeAdded = "_backup";
      const string result = "C:\\program files\\software\\application1_backup.txt";
      string result2 = FormMain.AddAtTheEndOfFileName(filePath, textToBeAdded);
      Assert.AreEqual(result, result2);
    }

    [TestMethod]
    public void TestIncreaseFileName()
    {
      const string FilePath = @"C:\Temp\_testForUnitTestVS\test.txt";
      Directory.CreateDirectory(@"C:\Temp\_testForUnitTestVS\");
      File.Create(FilePath);
      const string Result = @"C:\Temp\_testForUnitTestVS\test1.txt";
      Assert.AreEqual(Result, FormMain.IncreaseFileName(FilePath));
      //File.Delete(FilePath);

      const string FilePath2 = @"C:\Temp\_testForUnitTestVS\test99.txt";
      //File.Create(FilePath2);
      const string Result2 = @"C:\Temp\_testForUnitTestVS\test991.txt";
      Assert.AreEqual(Result2, FormMain.IncreaseFileName(FilePath2));
      //File.Delete(FilePath2);
      //Directory.Delete(@"C:\Temp\_testForUnitTestVS\");
    }

    [TestMethod]
    public void TestPluralWithWordChange()
    {
      Assert.AreEqual(string.Empty, FormMain.PluralWithWordChange(0));
      Assert.AreEqual(string.Empty, FormMain.PluralWithWordChange(1));
      Assert.AreEqual(string.Empty, FormMain.PluralWithWordChange(-6));
      Assert.AreEqual("s", FormMain.PluralWithWordChange(2));
      Assert.AreEqual("s", FormMain.PluralWithWordChange(2, "fr"));
      Assert.AreEqual("ies", FormMain.PluralWithWordChange(2, "eng"));
      Assert.AreEqual("ies", FormMain.PluralWithWordChange(2, "ENG"));
      Assert.AreEqual("y", FormMain.PluralWithWordChange(1, "eng"));
    }

    [TestMethod]
    public void TestPlural()
    {
      Assert.AreEqual(string.Empty, FormMain.Plural(0));
      Assert.AreEqual(string.Empty, FormMain.Plural(1));
      Assert.AreEqual(string.Empty, FormMain.Plural(-6));
      Assert.AreEqual("s", FormMain.Plural(2));
    }

    [TestMethod]
    public void TestGetApplicationTitle()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      string result = string.Format(" V{0}.{1}.{2}.{3}", fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart, fvi.FilePrivatePart);
      Assert.AreEqual(result, FormMain.GetApplicationTitle());
    }

    [TestMethod]
    public void TestGetDirectoryFileNameAndExtension()
    {
      const string filePath = @"C:\Temp\_testForUnitTestVS\test.txt";
      string[] result = new string[3];
      result[0] = @"C:\Temp\_testForUnitTestVS"; 
      result[1] = "test";
      result[2] = ".txt";
      string[] result2 = new string[3];
      result2 = FormMain.GetDirectoryFileNameAndExtension(filePath);
      for (int i = 0; i < result.Length; i++)
      {
        Assert.AreEqual(result[i], result2[i]);
      }
    }

    public bool CompareArrays(string[] array1, string[] array2)
    {
      bool result = true;
      for (int i = 0; i < array1.Length; i++)
      {
        try
        {
          Assert.AreEqual(array1[i], array2[i]);
        }
        catch (Exception)
        {
          result = false;
          break;
        }
      }

      return result;
    }

    [TestMethod]
    public void Test()
    {
      Assert.AreEqual(0, 0);
    }
  }
}