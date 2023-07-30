using Core.Configuration.Logic;
using Newtonsoft.Json;
using NLog;
using RestSharp;

namespace Core.SeleniumObjects.API
{
    public class BaseApiClient
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();

        private RestClient restClient;

        public BaseApiClient(string url)
        {
            var option = new RestClientOptions(url)
            {
                MaxTimeout = 10000,
                ThrowOnAnyError = false
            };

            restClient = new RestClient(option);
            restClient.AddDefaultHeader("Content-Type", "application/json");
        }

        public void AddToken()
        {
            var token = AppConfiguration.Api.Token;
            restClient.AddDefaultHeader("Token", token);
        }

        public RestResponse Execute(RestRequest request)
        {
            logger.Info("Executing Rest request with parameters:\n" + JsonConvert.SerializeObject(request));
            var response = restClient.Execute<RestResponse>(request);
            logger.Info("Response is:\n" + response.Content.Normalize());
            return response;
        }
    }
}