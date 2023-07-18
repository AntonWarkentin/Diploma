using Core;
using OpenQA.Selenium;

namespace BusinessObjects.ElementsObjects
{
    public class ProjectAccessTypeCheckboxes : BaseCheckboxesField
    {
        public override Dictionary<string, By> CheckBoxes { get; set; }
            
        private Dictionary<string, By> checkBoxes = new()
        {
            {"PrivateRadioButton", By.XPath("//input[@value='private']") },
            {"PublicRadioButton", By.XPath("//input[@value='public']") },
        };

        public ProjectAccessTypeCheckboxes()
        {
            CheckBoxes = checkBoxes;
        }

        public enum options
        {
            PrivateRadioButton,
            PublicRadioButton
        }
    }
}
