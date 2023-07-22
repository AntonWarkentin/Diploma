using Core.BaseObjects.UI;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BusinessObjects.UI.RadioButtonObjects
{
    public class ProjectAccessTypeRadioButtons : BaseRadioButtonsField<ProjectAccessOptions>
    {
        private Dictionary<ProjectAccessOptions, By> radioButtons = new()
        {
            {ProjectAccessOptions.PrivateRadioButton, By.XPath("//input[@value='private']") },
            {ProjectAccessOptions.PublicRadioButton, By.XPath("//input[@value='public']") },
        };

        public override void CheckOneOption(ProjectAccessOptions projectAccessOption)
        {
            driver.FindElement(radioButtons[projectAccessOption]).Click();
            Assert.IsTrue(driver.FindElement(radioButtons[projectAccessOption]).Selected);
        }
    }
}
