using OpenQA.Selenium;

namespace Core
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected string url = AppConfiguration.Browser.StartUrl;

        public BasePage()
        {
            driver = Browser.Instance.Driver;
        }

        public BasePage BaseOpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public abstract BasePage OpenPage();
    }
}
