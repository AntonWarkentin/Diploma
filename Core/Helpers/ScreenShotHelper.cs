using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.Helpers
{
    public static class ScreenShotHelper
    {
        public static void TakeScreenShot(this IWebDriver driver)
        {
            Directory.CreateDirectory("screenshots");

            var screenShotName = TestContext.CurrentContext.Test.Name + DateTime.Now.ToString("dd-MM-yyyy hh.mm.ss");
            Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();

            screenShot.SaveAsFile($"./screenshots/{screenShotName}.png", ScreenshotImageFormat.Png);
        }
    }
}
