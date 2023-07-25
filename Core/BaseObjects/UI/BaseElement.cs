using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Core.BaseObjects.UI
{
    public class BaseElement : BaseObject
    {
        protected By locator;

        public string Text { get => this.GetElement().Text; }
        public bool Selected { get => this.GetElement().Selected; }


        public IWebElement GetElement() => driver.FindElement(locator);
        public ReadOnlyCollection<IWebElement> GetElements() => driver.FindElements(locator);

        public BaseElement(string xpath)
        {
            locator = By.XPath(xpath);
        }

        public BaseElement(string xpath, string valueToInsert)
        {
            xpath = string.Format(xpath, valueToInsert);
            locator = By.XPath(xpath);
        }

        public string GetAttribute(string attributeName)
        {
            return this.GetElement().GetAttribute(attributeName);
        }
    }
}
