using BusinessObjects.API;
using BusinessObjects.DataModels.Models;
using BusinessObjects.DataModels.UI;
using Core.Helpers;

namespace Tests
{
    public class TestSteps
    {
        private const int amountOfCasesBulk = 3;
        
        public static List<string> CreateTestCasesBulkAndGetTitles(string projectCode)
        {
            var testData = TestCaseDataModelBuilder.NewTestCasesBulkModel(amountOfCasesBulk);
            var titles = new List<string>();

            foreach (var testCase in testData.Cases)
            {
                titles.Add(testCase.Title);
            }

            new TestCaseApiService().CreateTestCasesBulk(projectCode, testData);

            return titles;
        }

        public static string GetRandomExistingProjectCode()
        {
            var response = new ProjectApiService().GetAllProjects();
            return response.GetRandomEntry("result.entities[*].code").ToString();
        }

        public static string CreateSuiteForTest(string projectCode)
        {
            var testData = SuiteDataModelBuilder.NewSuiteModel();
            var responseCreateSuite = new SuiteApiService().CreateSuite(projectCode, testData);

            return responseCreateSuite.DeserializeJsonAndGetToken("result.id").ToString();
        }

        public static SuiteDataModel GetSuite(string projectCode, string suiteId)
        {
            var responseGetSpecificSuite = new SuiteApiService().GetSpecificSuite(projectCode, suiteId);
            return responseGetSpecificSuite.DeserializeJsonAndGetToken("result").ToObject<SuiteDataModel>();
        }
        
        public static DefectDataModel GetDefect(string projectCode, string defectId)
        {
            var responseGetSpecificSuite = new DefectApiService().GetSpecificDefect(projectCode, defectId);
            return responseGetSpecificSuite.DeserializeJsonAndGetToken("result").ToObject<DefectDataModel>();
        }
    }
}
