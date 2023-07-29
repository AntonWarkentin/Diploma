using BusinessObjects.DataModels.Models;
using Core.SeleniumObjects.API;
using Newtonsoft.Json;
using RestSharp;

namespace BusinessObjects.API
{
    public class SuiteApiService : BaseApiService
    {
        const string BaseSuiteEndpoint = "/suite/{code}";
        const string SpecificSuiteEndpoint = "/suite/{code}/{id}";


        public SuiteApiService() : base() { }

        public RestResponse CreateSuite(string projectCode, SuiteDataModel suite)
        {
            var request = new RestRequest(BaseSuiteEndpoint, Method.Post).
                            AddUrlSegment("code", projectCode);

            request.AddBody(JsonConvert.SerializeObject(suite), ContentType.Json);

            return apiClient.Execute(request);
        }

        public RestResponse GetSpecificSuite(string projectCode, string suiteId)
        {
            var request = new RestRequest(SpecificSuiteEndpoint).
                            AddUrlSegment("code", projectCode).
                            AddUrlSegment("id", suiteId);

            return apiClient.Execute(request);
        }

        public RestResponse DeleteSuite(string projectCode, string suiteId)
        {
            var request = new RestRequest(SpecificSuiteEndpoint, Method.Delete).
                            AddUrlSegment("code", projectCode).
                            AddUrlSegment("id", suiteId);

            return apiClient.Execute(request);
        }
        
        public RestResponse UpdateSuite(string projectCode, string suiteId, SuiteDataModel suite)
        {
            var request = new RestRequest(SpecificSuiteEndpoint, Method.Patch).
                            AddUrlSegment("code", projectCode).
                            AddUrlSegment("id", suiteId);

            request.AddBody(JsonConvert.SerializeObject(suite), ContentType.Json);

            return apiClient.Execute(request);
        }
    }
}
