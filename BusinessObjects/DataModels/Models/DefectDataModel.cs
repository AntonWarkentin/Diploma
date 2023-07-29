using Newtonsoft.Json;
using System.Globalization;

namespace BusinessObjects.DataModels.Models
{
    public class DefectDataModel
    {
        public enum Severities
        {
            undefined = 0,
            blocker = 1,
            critical = 2,
            major = 3,
            normal = 4,
            minor = 5,
            trivial = 6
        }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("actual_result", NullValueHandling = NullValueHandling.Ignore)]
        public string ActualResult { get; set; }
        
        [JsonProperty("severity", NullValueHandling = NullValueHandling.Ignore)]
        public string Severity { get; set; }

        public int SeverityInt
        {
            get
            {
                int result;
                if (int.TryParse(Severity,
                        NumberStyles.AllowThousands,
                        CultureInfo.InvariantCulture,
                        out result))
                    return result;
                else
                    return 0;
            }
        }

        [JsonProperty("tags.title", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is DefectDataModel model &&
                   Title == model.Title &&
                   ActualResult == model.ActualResult &&
                   ((Severities)SeverityInt).ToString() == model.Severity &&
                   EqualityComparer<string[]>.Default.Equals(Tags, model.Tags);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, ActualResult, Tags);
        }
    }
}