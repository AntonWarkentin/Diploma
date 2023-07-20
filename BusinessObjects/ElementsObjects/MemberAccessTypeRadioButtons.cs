using Core.BaseObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BusinessObjects.ElementsObjects
{
    public partial class MemberAccessTypeRadioButtons : BaseRadioButtonsField
    {
        private Dictionary<MemberAccessOptions, By> radioButtons = new()
        {
            {MemberAccessOptions.AddAllMembersRadioButton, By.XPath("//input[@value='all']") },
            {MemberAccessOptions.AddMembersFromGroupRadioButton, By.XPath("//input[@value='group']") },
            {MemberAccessOptions.DontAddMembersRadioButton, By.XPath("//input[@value='none']") },
        };

        private By groupToChooseInput = By.XPath("//input[@aria-autocomplete='list']");
        private By groupToChooseOptions = By.XPath("//div[@data-popper-placement='bottom-start']");

        public override void CheckOneOption<MemberAccessOptions>(MemberAccessOptions memberAccessOption)
        {
            var optionToCheck = (ElementsObjects.MemberAccessOptions)(object)memberAccessOption;

            driver.FindElement(radioButtons[optionToCheck]).Click();
            Assert.IsTrue(driver.FindElement(radioButtons[optionToCheck]).Selected);

            if (optionToCheck == ElementsObjects.MemberAccessOptions.AddMembersFromGroupRadioButton)
            {
                driver.FindElement(groupToChooseInput).Click();
                driver.FindElement(groupToChooseOptions).Click();
            }
        }
    }
}