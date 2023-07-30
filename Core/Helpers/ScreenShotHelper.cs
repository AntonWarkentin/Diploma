using NUnit.Framework;
using OpenQA.Selenium;

namespace Core.Helpers
{
    public static class ScreenShotHelper
    {
        public static Screenshot TakeScreenShot(this IWebDriver driver)
        {
            var screenShotName = TestContext.CurrentContext.Test.Name + DateTime.Now.ToString("dd-MM-yyyy hh.mm.ss");
            Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();

            return screenShot;
        }
    }
}
