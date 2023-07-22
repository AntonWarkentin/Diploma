using Core.BaseObjects.UI;
using NUnit.Framework;

namespace BusinessObjects.UI.RadioButtonObjects
{
    public partial class MemberAccessTypeRadioButtons : BaseRadioButtonsField<MemberAccessOptions>
    {
        private Dictionary<MemberAccessOptions, Button> radioButtons = new()
        {
            {MemberAccessOptions.AddAllMembersRadioButton, new("//input[@value='all']") },
            {MemberAccessOptions.AddMembersFromGroupRadioButton, new("//input[@value='group']") },
            {MemberAccessOptions.DontAddMembersRadioButton, new("//input[@value='none']") },
        };

        private DropDown groupToChooseInput = new("//input[@aria-autocomplete='list']");
        private string groupToChooseOption = "//div[@data-popper-placement='bottom-start']";

        public override void CheckOneOption(MemberAccessOptions memberAccessOption)
        {
            radioButtons[memberAccessOption].Click();
            Assert.IsTrue(radioButtons[memberAccessOption].Selected);

            if (memberAccessOption == MemberAccessOptions.AddMembersFromGroupRadioButton)
            {
                groupToChooseInput.SelectOption(groupToChooseOption);
            }
        }
    }
}