using BusinessObjects.DataModels.Models;
using Newtonsoft.Json.Linq;

namespace Core.Helpers
{
    public static class ConvertationHelper
    {
        public static TestCasesBulkModel ToTestCasesBulkModel(this JToken[] tokens)
        {
            var cases = new TestCasesBulkModel();
            cases.Cases = new TestCaseModel[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
            {
                cases.Cases[i] = tokens[i].ToObject<TestCaseModel>();
            }

            return cases;
        }
    }
}
