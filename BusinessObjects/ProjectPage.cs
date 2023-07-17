using Core;

namespace BusinessObjects
{
    public class ProjectPage : BasePage
    {
        string url = "https://app.qase.io/project/{0}";
        private string projectCode;

        public override ProjectPage OpenPage() => (ProjectPage)BaseOpenPage();

        public ProjectPage(string projectCode)
        {
            this.projectCode = projectCode;
            url = String.Format(url, projectCode);
        }
    }
}