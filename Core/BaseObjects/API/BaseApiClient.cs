using Core.Configuration.Logic;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Core.BaseObjects.API
{
    public class BaseApiClient
    {
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
            var response = restClient.Execute<RestResponse>(request);
            return response;
        }

        public T Execute<T>(RestRequest request)
        {
            var response = restClient.Execute<T>(request);
            return response.Data;
        }
    }
}