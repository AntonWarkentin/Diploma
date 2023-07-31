using BusinessObjects.API;
using BusinessObjects.DataModels.Builders;
using BusinessObjects.DataModels.Models;
using BusinessObjects.UI.PageObjects;
using Core.Helpers;
using NLog;

namespace Tests.Core
{
    public class TestSteps
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        private const int amountOfCasesBulk = 3;

        public static ProjectsPage Login()
        {
            return new LoginPage().
                    OpenPage().
                    Login();
        }

        public static List<string> CreateTestCasesBulkAndGetTitles(string projectCode)
        {
            logger.Info("Preparing test data for AT:");

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
            var randomExistingProjectCode = response.GetRandomEntry("result.entities[*].code").ToString();

            logger.Info("Getting project code for AT: " + randomExistingProjectCode);
            return randomExistingProjectCode;
        }

        public static string CreateSuiteForTest(string projectCode)
        {
            logger.Info("Preparing test data for AT:");

            var testData = SuiteDataModelBuilder.NewSuiteModel();
            var responseCreateSuite = new SuiteApiService().CreateSuite(projectCode, testData);

            return responseCreateSuite.DeserializeJsonAndGetToken("result.id").ToString();
        }

        public static string CreateDefectForTest(string projectCode)
        {
            logger.Info("Preparing test data for AT:");

            var testData = DefectDataModelBuilder.CreateDefectModel();
            var responseCreateDefect = new DefectApiService().CreateDefect(projectCode, testData);

            return responseCreateDefect.DeserializeJsonAndGetToken("result.id").ToString();
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