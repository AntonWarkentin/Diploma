using BusinessObjects.DataModels.UI;
using Core.BaseObjects.UI;
using NUnit.Framework;

namespace BusinessObjects.UI.PageObjects
{
    public class ProjectGeneralSettingsPage : BasePage
    {
        const string updateSettingsMessage = "Project settings were successfully updated!";

        string url = "https://app.qase.io/project/{0}/settings/general";

        private TextField ProjectNameField = new("//input[@id='project-name']");
        private TextField ProjectCodeField = new("//input[@id='project-code']");
        private TextField DescriptionField = new("//textarea[@id='description-area']");
        private Button UpdateSettingsButton = new("//button[@type='submit']");
        private BaseElement Alert = new("//div[@role='alert']/span/span");


        public ProjectGeneralSettingsPage(string projectCode) : base()
        {
            url = string.Format(url, projectCode);
        }

        public override ProjectGeneralSettingsPage OpenPage() => (ProjectGeneralSettingsPage)base.OpenPage();

        public void CheckOutProjectSettings(ProjectDataModel dataExpected)
        {
            var dataOnForm = new ProjectDataModel()
            {
                Name = ProjectNameField.GetAttribute("value"),
                Code = ProjectCodeField.GetAttribute("value"),
                Description = DescriptionField.Text
            };

            Assert.That(dataOnForm, Is.EqualTo(dataExpected));
        }

        public void UpdateSettings(ProjectDataModel updatedValues)
        {
            ProjectNameField.SendKeys(updatedValues.Name);
            DescriptionField.SendKeys(updatedValues.Description);
            UpdateSettingsButton.Click();
            Assert.That(Alert.Text, Is.EqualTo(updateSettingsMessage));
        }
    }
}