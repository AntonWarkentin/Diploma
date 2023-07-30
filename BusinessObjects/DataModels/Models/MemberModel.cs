using Core.BaseObjects.DataModels;
using Newtonsoft.Json;

namespace BusinessObjects.DataModels.Models
{
    public class MemberModel : BaseDataModel
    {
        [JsonProperty("member_id")]
        public int Id { get; set; }
    }
}