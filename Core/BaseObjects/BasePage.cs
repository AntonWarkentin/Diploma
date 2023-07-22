using Core.Configuration;
using OpenQA.Selenium;

namespace Core.BaseObjects
{
    public abstract class BasePage : BaseElement
    {
        protected string url = AppConfiguration.Browser.StartUrl;

        public BasePage() : base() { }

        public virtual BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
    }
}
