using Core.Configuration.Logic;
using NLog;

namespace Core.SeleniumObjects.API
{
    public class BaseApiService
    {
        public string BaseUrl = AppConfiguration.Api.BaseUrl;

        protected static readonly ThreadLocal<BaseApiService> BaseApiInstances = new();

        protected BaseApiClient apiClient;
        public BaseApiClient ApiClient { get { return apiClient; } }

        private static BaseApiService instance = null;
        public static BaseApiService Instance => GetBaseApiService();

        public BaseApiService()
        {
            apiClient = new BaseApiClient(BaseUrl);
            apiClient.AddToken();
        }

        private static BaseApiService GetBaseApiService()
        {
            return BaseApiInstances.Value ??= new BaseApiService();
        }
    }
}