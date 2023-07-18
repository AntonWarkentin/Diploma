using BusinessObjects.PageObjects;
using Core;

namespace Tests
{
    public class ProjectTests
    {
        [Test]
        public void CreateNewProjects()
        {
            new LoginPage().
                OpenPage().
                Login().
                OpenCreateNewProjectModal().
                CreateNewProject().
                CheckOutProjectNameAndCode();
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
