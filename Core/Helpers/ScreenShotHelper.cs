using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.Helpers
{
    public static class ScreenShotHelper
    {
        public static void TakeScreenShot(this IWebDriver driver)
        {
            var screenShotName = TestContext.CurrentContext.Test.FullName + DateTime.Now.ToString("dd-MM-yyyy hh.mm.ss");
            Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            screenShot.SaveAsFile($"./{screenShotName}.png", ScreenshotImageFormat.Png);
        }
    }
}
