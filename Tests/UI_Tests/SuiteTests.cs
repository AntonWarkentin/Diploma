using BusinessObjects.API;
using BusinessObjects.DataModels.Builders;
using NUnit.Allure.Attributes;
using Tests.Core;

namespace Tests.UI_Tests
{
    [AllureSuite("Suite UI Tests")]
    [Category("Suite Tests")]
    public class SuiteTests : BaseUITest
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
