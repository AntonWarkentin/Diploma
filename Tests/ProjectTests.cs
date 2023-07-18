using BusinessObjects.PageObjects;
using Core;

namespace Tests
{
    public class ProjectTests
    {
        [Test]
        public void CreateNewProjects()
        {
            var newProject = new LoginPage().
                OpenPage().
                Login().
                OpenCreateNewProjectModal().
                CreateNewProject();
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
