using BusinessObjects.API;
using BusinessObjects.DataModels.Builders;
using BusinessObjects.UI.PageObjects;
using Core.SeleniumObjects.UI;

namespace Tests
{
    public class UI_Tests
    {
        [Test]
        public void CreateNewProject()
        {
            var testData = ProjectDataModelBuilder.NewProjectModel();

            TestSteps.Login().
                CreateNewProject(testData).
                OpenSettings().
                CheckOutProjectSettings(testData);
        }
        
        [Test]
        public void DeleteProject()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();

            TestSteps.Login().
                DeleteProject(projectCode);
        }

        [Test]
        public void EditProjectTest()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var testData = ProjectDataModelBuilder.UpdateProjectModel();

            TestSteps.Login().
                OpenProjectSettings(projectCode).
                UpdateSettings(testData);
        }

        [Test]
        public void CreateNewSuite()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var testData = SuiteDataModelBuilder.NewSuiteModel();

            TestSteps.Login().
                OpenProject(projectCode).
                CreateSuite(testData);
        }

        [Test]
        public void CreateTestCase()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var testData = TestCaseDataModelBuilder.NewTestCaseModel();

            TestSteps.Login().
                OpenProject(projectCode).
                CreateTestCase(testData);
        }

        [Test]
        public void DeleteSuite()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var testData = SuiteDataModelBuilder.NewSuiteModel();

            new SuiteApiService().CreateSuite(projectCode, testData);

            TestSteps.Login().
                OpenProject(projectCode).
                DeleteSuite(testData.Title);
        }
        
        [Test]
        public void DeleteTestCase()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var testData = TestCaseDataModelBuilder.NewTestCaseModel();

            new TestCaseApiService().CreateTestCase(projectCode, testData);

            TestSteps.Login().
                OpenProject(projectCode).
                DeleteTestCase(testData.Title);
        }

        [Test]
        public void DeleteSeveralTestCases()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var testCaseTitles = TestSteps.CreateTestCasesBulkAndGetTitles(projectCode);

            TestSteps.Login().
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
