using BusinessObjects.API;
using BusinessObjects.DataModels.Builders;

namespace Tests.UI_Tests
{
    public class TestCaseTests : BaseTest
    {
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
    }
}
