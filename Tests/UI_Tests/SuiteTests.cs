using BusinessObjects.API;
using BusinessObjects.DataModels.Builders;

namespace Tests.UI_Tests
{
    public class SuiteTests : BaseTest
    {
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
        public void DeleteSuite()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var testData = SuiteDataModelBuilder.NewSuiteModel();

            new SuiteApiService().CreateSuite(projectCode, testData);

            TestSteps.Login().
                OpenProject(projectCode).
                DeleteSuite(testData.Title);
        }
    }
}
