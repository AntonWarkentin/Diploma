using BusinessObjects.DataModels;
using BusinessObjects.PageObjects;
using Core.SeleniumObjects;

namespace Tests
{
    public class ProjectTests
    {
        [Test]
        public void CreateNewProject()
        {
            var testData = NewProjectDataModelBuilder.CreateProjectWithFakedValues();

            new LoginPage().
                OpenPage().
                Login().
                CreateNewProject(testData).
                OpenSettings().
                CheckOutProjectSettings(testData);
        }

        [Test]
        public void DeleteProject()
        {
            new LoginPage().
                OpenPage().
                Login().
                DeleteProject("VVVVV");
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
