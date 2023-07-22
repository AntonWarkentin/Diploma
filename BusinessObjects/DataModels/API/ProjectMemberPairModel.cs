using Newtonsoft.Json;

namespace BusinessObjects.DataModels.API
{
    public class ProjectMemberPairModel
    {
        [JsonProperty("member_id")]
        public int MemberId { get; set; }

        [JsonProperty("code")]
        public string? ProjectCode { get; set; }
    }
}
