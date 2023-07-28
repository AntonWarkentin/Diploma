using BusinessObjects.API;
using BusinessObjects.DataModels.UI;
using Core.Helpers;

namespace Tests
{
    public class TestCaseSteps
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
    }
}
