using Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BusinessObjects.ElementsObjects
{
    public class ProjectAccessTypeRadioButtons : BaseRadioButtonsField
    {
        private Dictionary<ProjectAccessOptions, By> radioButtons = new ()
        {
            {ProjectAccessOptions.PrivateRadioButton, By.XPath("//input[@value='private']") },
            {ProjectAccessOptions.PublicRadioButton, By.XPath("//input[@value='public']") },
        };

        public override void CheckOneOption<ProjectAccessOptions>(ProjectAccessOptions projectAccessOption)
        {
            var optionToCheck = (ElementsObjects.ProjectAccessOptions)(object)projectAccessOption;
            driver.FindElement(radioButtons[optionToCheck]).Click();
            Assert.IsTrue(driver.FindElement(radioButtons[optionToCheck]).Selected);
        }
    }
}
