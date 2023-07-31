using Core.BaseObjects.DataModels;
using Newtonsoft.Json;

namespace BusinessObjects.DataModels.Models
{
    public class TestCaseModel : BaseDataModel
    {
        public int Id { get; set; }
        public int Position { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        public string Status { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        public string SeverityStr { get; set; }

        public string PriorityStr { get; set; }

        [JsonProperty("behavior", NullValueHandling = NullValueHandling.Ignore)]
        public int Behavior { get; set; }

        public string BehaviorStr { get; set; }

        public string IsFlakyStr { get; set; }

        public string Type { get; set; }

        public string AutomationStatus { get; set; }

        [JsonProperty("layer", NullValueHandling = NullValueHandling.Ignore)]
        public int Layer { get; set; }

        public string LayerStr { get; set; }

        [JsonProperty("preconditions", NullValueHandling = NullValueHandling.Ignore)]
        public string Preconditions { get; set; }

        [JsonProperty("postconditions", NullValueHandling = NullValueHandling.Ignore)]
        public string Postconditions { get; set; }

        [JsonProperty("severity")]
        public int Severity { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("is_flaky", NullValueHandling = NullValueHandling.Ignore)]
        public int? IsFlaky { get; set; }

        [JsonProperty("suite_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? SuiteId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TestCaseModel model &&
                   Title == model.Title &&
                   Status == model.Status &&
                   Description == model.Description &&
                   SeverityStr == model.SeverityStr &&
                   PriorityStr == model.PriorityStr &&
                   Behavior == model.Behavior &&
                   BehaviorStr == model.BehaviorStr &&
                   IsFlakyStr == model.IsFlakyStr &&
                   Type == model.Type &&
                   AutomationStatus == model.AutomationStatus &&
                   Layer == model.Layer &&
                   LayerStr == model.LayerStr &&
                   Preconditions == model.Preconditions &&
                   Postconditions == model.Postconditions &&
                   Severity == model.Severity &&
                   Priority == model.Priority &&
                   IsFlaky == model.IsFlaky &&
                   SuiteId == model.SuiteId;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Title);
            hash.Add(Status);
            hash.Add(Description);
            hash.Add(SeverityStr);
            hash.Add(PriorityStr);
            hash.Add(Behavior);
            hash.Add(BehaviorStr);
            hash.Add(IsFlakyStr);
            hash.Add(Type);
            hash.Add(AutomationStatus);
            hash.Add(Layer);
            hash.Add(LayerStr);
            hash.Add(Preconditions);
            hash.Add(Postconditions);
            hash.Add(Severity);
            hash.Add(Priority);
            hash.Add(IsFlaky);
            hash.Add(SuiteId);
            return hash.ToHashCode();
        }
    }
}