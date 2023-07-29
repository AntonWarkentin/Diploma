using BusinessObjects.DataModels.Models;
using Core.SeleniumObjects.API;
using Newtonsoft.Json;
using RestSharp;

namespace BusinessObjects.API
{
    public class DefectApiService : BaseApiService
    {
        const string BaseDefectEndpoint = "/defect/{code}";
        const string SpecificDefectEndpoint = "/defect/{code}/{id}";

        public DefectApiService() : base() { }

        public RestResponse CreateDefect(string projectCode, DefectDataModel defect)
        {
            var request = new RestRequest(BaseDefectEndpoint, Method.Post).
                            AddUrlSegment("code", projectCode);

            request.AddBody(JsonConvert.SerializeObject(defect), ContentType.Json);

            return apiClient.Execute(request);
        }
        
        public RestResponse GetSpecificDefect(string projectCode, string defectId)
        {
            var request = new RestRequest(SpecificDefectEndpoint).
                            AddUrlSegment("code", projectCode).
                            AddUrlSegment("id", defectId);

            return apiClient.Execute(request);
        }

        public RestResponse UpdateDefect(string projectCode, string defectId, DefectDataModel defect)
        {
            var request = new RestRequest(SpecificDefectEndpoint, Method.Patch).
                            AddUrlSegment("code", projectCode).
                            AddUrlSegment("id", defectId);

            request.AddBody(JsonConvert.SerializeObject(defect), ContentType.Json);

            return apiClient.Execute(request);
        }
        
        public RestResponse DeleteDefect(string projectCode, string defectId)
        {
            var request = new RestRequest(SpecificDefectEndpoint, Method.Delete).
                            AddUrlSegment("code", projectCode).
                            AddUrlSegment("id", defectId);

            return apiClient.Execute(request);
        }
    }
}
