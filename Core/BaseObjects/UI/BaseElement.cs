using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Core.BaseObjects.UI
{
    public class BaseElement : BaseObject
    {
        protected By locator;

        public string Text { get => this.GetElement().Text; }
        public bool Selected { get => this.GetElement().Selected; }
        public bool Displayed { get => this.GetElement().Displayed; }
        public bool NotDisplayed { get => this.GetElements().Count == 0; }


        public IWebElement GetElement()
        {
            wait.Until(x => x.FindElement(locator));
            return driver.FindElement(locator);
        }

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

        public BaseElement(By by)
        {
            locator = by;
        }

        public string GetAttribute(string attributeName)
        {
            return this.GetElement().GetAttribute(attributeName);
        }

        public void AssertElementExistence(bool isExisting)
        {
            var foundElements = this.GetElements();
            Assert.That(foundElements.Count > 0, Is.EqualTo(isExisting));
        }
    }
}
