using BusinessObjects.API;
using BusinessObjects.DataModels.Builders;
using Core.Helpers;
using NUnit.Allure.Attributes;
using System.Net;
using Tests.Core;

namespace Tests.API_Tests
{
    [AllureSuite("Defect API Tests")]
    [Category("Defect Tests")]
    public class DefectTests : BaseTest
    {
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
