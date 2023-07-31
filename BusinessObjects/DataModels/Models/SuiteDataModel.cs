using Core.BaseObjects.DataModels;
using Newtonsoft.Json;

namespace BusinessObjects.DataModels.Models
{
    public class SuiteDataModel : BaseDataModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("preconditions", NullValueHandling = NullValueHandling.Ignore)]
        public string Preconditions { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is SuiteDataModel model &&
                   Title == model.Title &&
                   Description == model.Description &&
                   Preconditions == model.Preconditions;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Description, Preconditions);
        }
    }
}
