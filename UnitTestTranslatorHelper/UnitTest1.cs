using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatorHelper;

namespace UnitTestTranslatorHelper
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      Assert.AreEqual("01h:01m:17s:000ms", FormMain.StripZeroTime("01h:01m:17s:000ms"));
      Assert.AreEqual("01m:17s:000ms", FormMain.StripZeroTime("00h:01m:17s:000ms"));
      Assert.AreEqual("17s:000ms", FormMain.StripZeroTime("00h:00m:17s:000ms"));
      Assert.AreEqual("900ms", FormMain.StripZeroTime("00h:00m:00s:900ms"));

    }
  }
}