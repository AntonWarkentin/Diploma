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
            var projectCode = TestCaseSteps.GetRandomExistingProjectCode();

            new LoginPage().
                OpenPage().
                Login().
                DeleteProject(projectCode).
                AssertProjectExistence(projectCode, false);
        }

        [Test]
        public void EditProjectTest()
        {
            var testData = ProjectDataModelBuilder.UpdateProjectModel();
            var projectCode = TestCaseSteps.GetRandomExistingProjectCode();

            new LoginPage().
                OpenPage().
                Login().
                OpenProjectSettings(projectCode).
                UpdateSettings(testData);
        }

        [Test]
        public void CreateNewSuite()
        {
            var testData = SuiteDataModelBuilder.NewSuiteModel();
            var projectCode = TestCaseSteps.GetRandomExistingProjectCode();

            new LoginPage().
                OpenPage().
                Login().
                OpenProject(projectCode).
                CreateSuite(testData);
        }

        [Test]
        public void CreateTestCase()
        {
            var testData = TestCaseDataModelBuilder.NewTestCaseModel();
            var projectCode = TestCaseSteps.GetRandomExistingProjectCode();

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
            var projectCode = TestCaseSteps.GetRandomExistingProjectCode();

            new SuiteApiService().CreateSuite(projectCode, testData);

            new LoginPage().
                OpenPage().
                Login().
                OpenProject(projectCode).
                DeleteSuite(testData.Title);
        }
        
        [Test]
        public void DeleteTestCase()
        {
            var testData = TestCaseDataModelBuilder.NewTestCaseModel();

            var projectCode = TestCaseSteps.GetRandomExistingProjectCode();

            new TestCaseApiService().CreateTestCase(projectCode, testData);

            new LoginPage().
                OpenPage().
                Login().
                OpenProject(projectCode).
                DeleteTestCase(testData.Title);
        }

        [Test]
        public void DeleteSeveralTestCases()
        {
            var projectCode = TestCaseSteps.GetRandomExistingProjectCode();
            var testCaseTitles = TestCaseSteps.CreateTestCasesBulkAndGetTitles(projectCode);

            new LoginPage().
                OpenPage().
                Login().
                OpenProject(projectCode).
                DeleteTestCasesBulk(testCaseTitles);
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
