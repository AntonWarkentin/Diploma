using System.Text.Json.Serialization;

namespace BusinessObjects.DataModels.Models
{
    public class CreateProjectModel
    {
        public string Title { get; set; }
        public string Code { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Access { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Group { get; set; }
    }
}