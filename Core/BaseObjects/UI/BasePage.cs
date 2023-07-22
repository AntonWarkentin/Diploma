using Core.Configuration.Logic;
using OpenQA.Selenium;

namespace Core.BaseObjects.UI
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
