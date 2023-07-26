using Core.Configuration.Logic;

namespace Core.SeleniumObjects.API
{
    public class BaseApiService
    {
        protected BaseApiClient apiClient;
        public string BaseUrl = AppConfiguration.Api.BaseUrl;

        public BaseApiService()
        {
            apiClient = new BaseApiClient(BaseUrl);
            apiClient.AddToken();
        }
    }
}