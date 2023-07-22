using OpenQA.Selenium;

namespace Core.BaseObjects.UI
{
    public class BaseElement : BaseObject
    {
        public IWebElement GetElement() => driver.FindElement(locator);
        protected By locator;

        public string Text { get => this.GetElement().Text; }
        public bool Selected { get => this.GetElement().Selected; }

        public BaseElement(string xpath)
        {
            locator = By.XPath(xpath);
        }

        public string GetAttribute(string attributeName)
        {
            return this.GetElement().GetAttribute(attributeName);
        }
    }
}
