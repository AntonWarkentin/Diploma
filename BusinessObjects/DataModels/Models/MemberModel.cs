using Newtonsoft.Json;

namespace BusinessObjects.DataModels.Models
{
    public class MemberModel
    {
        [JsonProperty("member_id")]
        public int Id { get; set; }
    }
}