using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatorHelper;

namespace UnitTestTranslatorHelper
{
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
  }
}