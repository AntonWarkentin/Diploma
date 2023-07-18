using NUnit.Framework;
using OpenQA.Selenium;

namespace Core
{
    public abstract class BaseCheckboxesField
    {
        protected IWebDriver driver => Browser.Instance.Driver;

        public abstract Dictionary<string, By> CheckBoxes { get; set; }

        public void CheckOneOption(string optionToCheck)
        {
            driver.FindElement(CheckBoxes[optionToCheck]).Click();

            foreach (var checkbox in CheckBoxes)
            {
                var element = driver.FindElement(checkbox.Value);

                if (checkbox.Key == optionToCheck)
                {
                    Assert.IsTrue(element.Selected);
                }
                else
                {
                    Assert.IsFalse(element.Selected);
                }
            }
        }
    }
}
