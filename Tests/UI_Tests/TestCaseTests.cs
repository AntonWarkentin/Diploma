using BusinessObjects.API;
using BusinessObjects.DataModels.Builders;
using NUnit.Allure.Attributes;
using Tests.Core;

namespace Tests.UI_Tests
{
    [AllureSuite("TestCase UI Tests")]
    [Category("Test Case Tests")]
    public class TestCaseTests : BaseUITest
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
