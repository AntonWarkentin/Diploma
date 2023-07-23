using BusinessObjects.DataModels.UI;
using Core.BaseObjects.UI;
using NUnit.Framework;

namespace BusinessObjects.UI.PageObjects
{
    public class ProjectGeneralSettingsPage : BasePage
    {
        string url = "https://app.qase.io/project/{0}/settings/general";

        private TextField ProjectNameField = new("//input[@id='project-name']");
        private TextField ProjectCodeField = new("//input[@id='project-code']");
        private TextField DescriptionField = new("//textarea[@id='description-area']");

        public ProjectGeneralSettingsPage(string projectCode) : base()
        {
            url = string.Format(url, projectCode);
        }

        public override ProjectGeneralSettingsPage OpenPage() => (ProjectGeneralSettingsPage)base.OpenPage();

        public void CheckOutProjectSettings(NewProjectDataModel dataExpected)
        {
            var dataOnForm = new NewProjectDataModel()
            {
                Name = ProjectNameField.GetAttribute("value"),
                Code = ProjectCodeField.GetAttribute("value"),
                Description = DescriptionField.Text
            };

            Assert.That(dataOnForm, Is.EqualTo(dataExpected));
        }
    }
}