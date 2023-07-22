using Core.BaseObjects.UI;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BusinessObjects.UI.RadioButtonObjects
{
    public partial class MemberAccessTypeRadioButtons : BaseRadioButtonsField<MemberAccessOptions>
    {
        private Dictionary<MemberAccessOptions, By> radioButtons = new()
        {
            {MemberAccessOptions.AddAllMembersRadioButton, By.XPath("//input[@value='all']") },
            {MemberAccessOptions.AddMembersFromGroupRadioButton, By.XPath("//input[@value='group']") },
            {MemberAccessOptions.DontAddMembersRadioButton, By.XPath("//input[@value='none']") },
        };

        private By groupToChooseInput = By.XPath("//input[@aria-autocomplete='list']");
        private By groupToChooseOptions = By.XPath("//div[@data-popper-placement='bottom-start']");

        public override void CheckOneOption(MemberAccessOptions memberAccessOption)
        {
            driver.FindElement(radioButtons[memberAccessOption]).Click();
            Assert.IsTrue(driver.FindElement(radioButtons[memberAccessOption]).Selected);

            if (memberAccessOption == MemberAccessOptions.AddMembersFromGroupRadioButton)
            {
                driver.FindElement(groupToChooseInput).Click();
                driver.FindElement(groupToChooseOptions).Click();
            }
        }
    }
}