using BusinessObjects.API;
using BusinessObjects.DataModels.Builders;
using BusinessObjects.DataModels.UI;
using Core.Helpers;
using NUnit.Framework.Interfaces;
using System.Net;

namespace Tests
{
    public class API_Tests
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
            var responseSuiteId = responseDeleteSuite.DeserializeJsonAndGetToken("result.id").ToString();

            var responseGetSpecificSuite = new SuiteApiService().GetSpecificSuite(projectCode, responseSuiteId);
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

        [Test]
        public static void CreateDefect()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var testData = DefectDataModelBuilder.CreateDefectModel();

            var responseCreateDefect = new DefectApiService().CreateDefect(projectCode, testData);
            Assert.IsTrue(responseCreateDefect.StatusCode.Equals(HttpStatusCode.OK));

            var responseDefectId = responseCreateDefect.DeserializeJsonAndGetToken("result.id").ToString();
            var responsedDefect = TestSteps.GetDefect(projectCode, responseDefectId);
            Assert.That(responsedDefect, Is.EqualTo(testData));
        }
    }
}