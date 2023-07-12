using OpenQA.Selenium;
using Core;

namespace Core
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected string url;

        public BasePage()
        {
            driver = Browser.Instance.Driver;
        }
    }
}
