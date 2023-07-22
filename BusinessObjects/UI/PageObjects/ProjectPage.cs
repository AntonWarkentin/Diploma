using Core.BaseObjects.UI;

namespace BusinessObjects.UI.PageObjects
{
    public class ProjectPage : BasePage
    {
        string url = "https://app.qase.io/project/{0}";
        string code;

        private Button Settings = new("//a[@title='Settings']");

        public ProjectPage(string projectCode) : base()
        {
            code = projectCode;
            url = string.Format(url, projectCode);
        }

        public override ProjectPage OpenPage() => (ProjectPage)base.OpenPage();

        public ProjectGeneralSettingsPage OpenSettings()
        {
            Settings.Click();
            return new ProjectGeneralSettingsPage(code);
        }
    }
}