using Newtonsoft.Json;

namespace BusinessObjects.DataModels.API
{
    public class MemberModel
    {
        [JsonProperty("member_id")]
        public int Id { get; set; }
    }
}