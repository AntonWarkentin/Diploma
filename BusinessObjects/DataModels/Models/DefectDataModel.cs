using Newtonsoft.Json;

namespace BusinessObjects.DataModels.Models
{
    public class DefectDataModel
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("actual_result", NullValueHandling = NullValueHandling.Ignore)]
        public string ActualResult { get; set; }
        
        [JsonProperty("severity", NullValueHandling = NullValueHandling.Ignore)]
        public string Severity { get; set; }
        
        [JsonProperty("custom_field", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> CustomField { get; set; }

        [JsonProperty("tags.title", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is DefectDataModel model &&
                   Title == model.Title &&
                   ActualResult == model.ActualResult &&
                   //Severity == model.Severity &&
                   EqualityComparer<Dictionary<string, string>>.Default.Equals(CustomField, model.CustomField) &&
                   EqualityComparer<string[]>.Default.Equals(Tags, model.Tags);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, ActualResult, /*Severity,*/ CustomField, Tags);
        }
    }
}
