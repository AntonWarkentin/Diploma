using Core.Configuration.Logic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Core.SeleniumObjects.UI
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            if (AppConfiguration.Browser.Headless) options.AddArgument("--headless");

            options.AddArgument("--disable-gpu");
            options.AddArgument("incognito");
            options.AddArgument("--start-maximized");

            return new ChromeDriver(options);
        }

        public static IWebDriver CreateFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");

            return new FirefoxDriver(options);
        }
    }
}