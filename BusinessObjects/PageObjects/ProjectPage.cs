using Core;

namespace BusinessObjects.PageObjects
{
    public class ProjectPage : BasePage
    {
        string url = "https://app.qase.io/project/{0}";
        private string projectCode;

        public override ProjectPage OpenPage() => (ProjectPage)BaseOpenPage();

        public ProjectPage(string projectCode)
        {
            this.projectCode = projectCode;
            url = string.Format(url, projectCode);
        }
    }
}