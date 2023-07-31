using Newtonsoft.Json;

namespace Core.BaseObjects.DataModels
{
    public class BaseDataModel
    {
        public override string? ToString()
        {
            return "\n" + this.GetType() + JsonConvert.SerializeObject(this);
        }
    }
}
