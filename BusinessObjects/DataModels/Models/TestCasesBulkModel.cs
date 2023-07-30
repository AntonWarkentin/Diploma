using Core.BaseObjects.DataModels;
using Newtonsoft.Json;
using System.Text;

namespace BusinessObjects.DataModels.Models
{
    public class TestCasesBulkModel : BaseDataModel
    {
        [JsonProperty("cases")]
        public TestCaseModel[] Cases { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TestCasesBulkModel model &&
                   Cases.SequenceEqual(model.Cases);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Cases);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach(TestCaseModel testCase in Cases)
            {
                stringBuilder.Append(testCase.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}