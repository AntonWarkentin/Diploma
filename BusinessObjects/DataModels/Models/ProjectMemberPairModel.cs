using Core.BaseObjects.DataModels;
using Newtonsoft.Json;

namespace BusinessObjects.DataModels.Models
{
    public class ProjectMemberPairModel : BaseDataModel
    {
        [JsonProperty("member_id")]
        public int MemberId { get; set; }

        [JsonProperty("code")]
        public string? ProjectCode { get; set; }
    }
}
