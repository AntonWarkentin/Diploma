using Newtonsoft.Json;

namespace BusinessObjects.DataModels.Models
{
    public class DefectDataModel
    {
        static Dictionary<string, string> SeverityDict = new()
        {
            ["0"] = "undefined",
            ["1"] = "blocker",
            ["2"] = "critical",
            ["3"] = "major",
            ["4"] = "normal",
            ["5"] = "minor",
            ["6"] = "trivial",
        };

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("actual_result", NullValueHandling = NullValueHandling.Ignore)]
        public string ActualResult { get; set; }
        
        [JsonProperty("severity", NullValueHandling = NullValueHandling.Ignore)]
        public string Severity { get; set; }

        [JsonProperty("tags.title", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is DefectDataModel model &&
                   Title == model.Title &&
                   ActualResult == model.ActualResult &&
                   SeverityDict[Severity] == model.Severity &&
                   EqualityComparer<string[]>.Default.Equals(Tags, model.Tags);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, ActualResult, Tags);
        }
    }
}