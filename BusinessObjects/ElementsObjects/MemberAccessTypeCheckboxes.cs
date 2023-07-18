using Core;
using OpenQA.Selenium;

namespace BusinessObjects.ElementsObjects
{
    public class MemberAccessTypeCheckboxes : BaseCheckboxesField
    {
        public override Dictionary<string, By> CheckBoxes { get; set; }

        private Dictionary<string, By> checkBoxes = new()
        {
            {"AddAllMembersRadioButton", By.XPath("//input[@value='all']") },
            {"AddMembersFromGroupRadioButton", By.XPath("//input[@value='group']") },
            {"DontAddMembersRadioButton", By.XPath("//input[@value='none']") },
        };

        public MemberAccessTypeCheckboxes()
        {
            CheckBoxes = checkBoxes;
        }

        public enum options
        {
            AddAllMembersRadioButton,
            AddMembersFromGroupRadioButton,
            DontAddMembersRadioButton
        }
    }
}