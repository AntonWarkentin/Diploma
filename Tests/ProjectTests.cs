using BusinessObjects.API;
using BusinessObjects.DataModels.UI;
using BusinessObjects.UI.PageObjects;
using Core.Helpers;
using Core.SeleniumObjects.UI;

namespace Tests
{
    public class ProjectTests
    {
        [Test]
        public void CreateNewProject()
        {
            var testData = ProjectDataModelBuilder.NewProjectModel();

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
            var response = new ProjectApiService().GetAllProjects();
            var codeToDelete = response.GetRandomEntry("result.entities[*].code").ToString();

            new LoginPage().
                OpenPage().
                Login().
                DeleteProject(codeToDelete).
                AssertProjectExistence(codeToDelete, false);
        }

        [Test]
        public void EditProjectTest()
        {
            var testData = ProjectDataModelBuilder.UpdateProjectModel();
            var response = new ProjectApiService().GetAllProjects();
            var codeToEdit = response.GetRandomEntry("result.entities[*].code").ToString();

            new LoginPage().
                OpenPage().
                Login().
                OpenProjectSettings(codeToEdit).
                UpdateSettings(testData);
        }

        [Test]
        public void CreateNewSuite()
        {
            var testData = SuiteDataModelBuilder.NewSuiteModel();
            var response = new ProjectApiService().GetAllProjects();
            var projectCode = response.GetRandomEntry("result.entities[*].code").ToString();

            new LoginPage().
                OpenPage().
                Login().
                OpenProject(projectCode).
                CreateSuite(testData).
                AssertSuiteExistence(testData.Title, true);
        }

        [Test]
        public void CreateTestCase()
        {
            var testData = TestCaseDataModelBuilder.NewTestCaseModel();
            var response = new ProjectApiService().GetAllProjects();
            var projectCode = response.GetRandomEntry("result.entities[*].code").ToString();

            new LoginPage().
                OpenPage().
                Login().
                OpenProject(projectCode).
                CreateTestCase(testData);
        }

        [Test]
        public void DeleteSuite()
        {
            var testData = SuiteDataModelBuilder.NewSuiteModel();
            var response = new ProjectApiService().GetAllProjects();
            var projectCode = response.GetRandomEntry("result.entities[*].code").ToString();

            new SuiteApiService().CreateSuite(projectCode, testData);

            new LoginPage().
                OpenPage().
                Login().
                OpenProject(projectCode).
                DeleteSuite(testData.Title);
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
