using Core.Configuration.Logic;
using Core.Configuration.Models;
using Newtonsoft.Json.Linq;

namespace Core.SeleniumObjects.API
{
    public class BaseApiService
    {
        protected BaseApiClient apiClient;
        public string BaseUrl = AppConfiguration.Api.BaseUrl;

        public BaseApiService()
        {
            apiClient = new BaseApiClient(BaseUrl);
        }
    }
}