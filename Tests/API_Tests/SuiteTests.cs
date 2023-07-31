using BusinessObjects.API;
using BusinessObjects.DataModels.Builders;
using Core.Helpers;
using NUnit.Allure.Attributes;
using System.Net;
using Tests.Core;

namespace Tests.API_Tests
{
    [AllureSuite("Suite API Tests")]
    public class SuiteTests : BaseTest
    {
        [Test]
        public static void CreateNewSuite()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var testData = SuiteDataModelBuilder.NewSuiteModel();

            var responseCreateSuite = new SuiteApiService().CreateSuite(projectCode, testData);
            Assert.IsTrue(responseCreateSuite.StatusCode.Equals(HttpStatusCode.OK));

            var responseSuiteId = responseCreateSuite.DeserializeJsonAndGetToken("result.id").ToString();
            var responsedSuite = TestSteps.GetSuite(projectCode, responseSuiteId);
            Assert.That(responsedSuite, Is.EqualTo(testData));
        }

        [Test]
        public static void DeleteSuite()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var suiteId = TestSteps.CreateSuiteForTest(projectCode);

            var responseDeleteSuite = new SuiteApiService().DeleteSuite(projectCode, suiteId);
            Assert.IsTrue(responseDeleteSuite.StatusCode.Equals(HttpStatusCode.OK));

            var responseGetSpecificSuite = new SuiteApiService().GetSpecificSuite(projectCode, suiteId);
            Assert.IsTrue(responseGetSpecificSuite.StatusCode.Equals(HttpStatusCode.NotFound));
        }

        [Test]
        public static void UpdateSuite()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var suiteId = TestSteps.CreateSuiteForTest(projectCode);
            var testData = SuiteDataModelBuilder.UpdateSuiteModel();

            var responseUpdateSuite = new SuiteApiService().UpdateSuite(projectCode, suiteId, testData);
            Assert.IsTrue(responseUpdateSuite.StatusCode.Equals(HttpStatusCode.OK));

            var responsedSuite = TestSteps.GetSuite(projectCode, suiteId);
            Assert.That(responsedSuite, Is.EqualTo(testData));
        }
    }
}