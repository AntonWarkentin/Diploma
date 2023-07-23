using OpenQA.Selenium;

namespace Core.BaseObjects.UI
{
    public class DropDown : BaseElement
    {
        public DropDown(string xpath) : base(xpath) { }

        public void SelectOption(string optionXpath)
        {
            this.GetElement().Click();
            driver.FindElement(By.XPath(optionXpath)).Click();
        }
    }
}
