using BusinessObjects.DataModels.API;
using Core.SeleniumObjects.API;
using Newtonsoft.Json;
using RestSharp;

namespace BusinessObjects.API
{
    public class ProjectApiService : BaseApiService
    {
        public string ProjectEndpoint = "/project";
        public string ProjectByCodeEndpoint = "/project/{code}";
        public string ProjectAccessEndpoint = "/project/{code}/access";

        public ProjectApiService() : base() { }

        public RestResponse GetProjectByCode(string code)
        {
            var request = new RestRequest(ProjectByCodeEndpoint).
                            AddUrlSegment("code", code);

            return apiClient.Execute(request);
        }

        public RestResponse GetAllProjects()
        {
            var request = new RestRequest(ProjectEndpoint);
            return apiClient.Execute(request);
        }

        public RestResponse CreateProject(CreateProjectModel project)
        {
            var request = new RestRequest(ProjectEndpoint, Method.Post);
            request.AddBody(project);
            return apiClient.Execute(request);
        }

        public RestResponse DeleteProject(string code)
        {
            var request = new RestRequest(ProjectByCodeEndpoint, Method.Delete).
                            AddUrlSegment("code", code);

            return apiClient.Execute(request);
        }

        public RestResponse GrantAccessToProject(string projectCode, MemberModel member)
        {
            var memberSerialized = JsonConvert.SerializeObject(member);

            var request = new RestRequest(ProjectAccessEndpoint, Method.Post).
                            AddUrlSegment("code", projectCode);

            request.AddBody(memberSerialized);
            return apiClient.Execute(request);
        }

        public RestResponse RevokeAccessToProject(string projectCode, MemberModel member)
        {
            var memberSerialized = JsonConvert.SerializeObject(member);

            var request = new RestRequest(ProjectAccessEndpoint, Method.Delete).
                            AddUrlSegment("code", projectCode);

            request.AddBody(memberSerialized);
            return apiClient.Execute(request);
        }
    }
}