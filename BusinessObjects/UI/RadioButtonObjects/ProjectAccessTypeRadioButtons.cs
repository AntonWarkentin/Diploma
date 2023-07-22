using Core.BaseObjects.UI;
using NUnit.Framework;

namespace BusinessObjects.UI.RadioButtonObjects
{
    public class ProjectAccessTypeRadioButtons : BaseRadioButtonsField<ProjectAccessOptions>
    {
        private Dictionary<ProjectAccessOptions, Button> radioButtons = new()
        {
            {ProjectAccessOptions.PrivateRadioButton, new("//input[@value='private']") },
            {ProjectAccessOptions.PublicRadioButton, new("//input[@value='public']") },
        };

        public override void CheckOneOption(ProjectAccessOptions projectAccessOption)
        {
            radioButtons[projectAccessOption].Click();
            Assert.IsTrue(radioButtons[projectAccessOption].Selected);
        }
    }
}
