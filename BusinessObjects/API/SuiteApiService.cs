using BusinessObjects.DataModels.UI;
using Core.SeleniumObjects.API;
using Newtonsoft.Json;
using RestSharp;

namespace BusinessObjects.API
{
    public class SuiteApiService : BaseApiService
    {
        public string SuiteEndpoint = "/suite/{code}";

        public SuiteApiService() : base() { }

        public RestResponse CreateSuite(string projectCode, SuiteDataModel suite)
        {
            var request = new RestRequest(SuiteEndpoint, Method.Post).
                            AddUrlSegment("code", projectCode);

            request.AddBody(JsonConvert.SerializeObject(suite), ContentType.Json);

            return apiClient.Execute(request);
        }
    }
}
