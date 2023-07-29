using BusinessObjects.API;
using BusinessObjects.DataModels.Builders;
using Core.Helpers;
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
        
        [Test]
        public static void UpdateDefect()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var testData = DefectDataModelBuilder.UpdateDefectModel();
            var defectId = TestSteps.CreateDefectForTest(projectCode);

            var responseUpdateDefect = new DefectApiService().UpdateDefect(projectCode, defectId, testData);
            Assert.IsTrue(responseUpdateDefect.StatusCode.Equals(HttpStatusCode.OK));

            var responsedDefect = TestSteps.GetDefect(projectCode, defectId);
            Assert.That(responsedDefect, Is.EqualTo(testData));
        }
        
        [Test]
        public static void DeleteDefect()
        {
            var projectCode = TestSteps.GetRandomExistingProjectCode();
            var defectId = TestSteps.CreateDefectForTest(projectCode);

            var responseDeleteDefect = new DefectApiService().DeleteDefect(projectCode, defectId);
            Assert.IsTrue(responseDeleteDefect.StatusCode.Equals(HttpStatusCode.OK));

            var responseGetSpecificSuite = new DefectApiService().GetSpecificDefect(projectCode, defectId);
            Assert.IsTrue(responseGetSpecificSuite.StatusCode.Equals(HttpStatusCode.NotFound));
        }
    }
}