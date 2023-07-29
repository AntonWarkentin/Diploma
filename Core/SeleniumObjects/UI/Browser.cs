using Core.Configuration.Logic;
using OpenQA.Selenium;

namespace Core.SeleniumObjects.UI
{
    public class Browser
    {
        private static readonly ThreadLocal<Browser> BrowserInstances = new();

        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }

        private static Browser instance = null;

        public static Browser Instance => GetBrowser();

        private static Browser GetBrowser()
        {
            return BrowserInstances.Value ??= new Browser();
        }


        private Browser()
        {
            driver = WebDriverFactory.CreateChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AppConfiguration.Browser.TimeOut);
            driver.Manage().Window.Maximize();
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            BrowserInstances.Value = null;
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
