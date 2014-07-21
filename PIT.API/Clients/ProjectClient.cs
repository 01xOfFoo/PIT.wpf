using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using PIT.API.Clients.Contracts;
using PIT.API.HTTP;
using PIT.API.Validators.Contracts;
using PIT.Business.Entities;

namespace PIT.API.Clients
{
    public class ProjectClient : BaseClient, IProjectClient
    {
        private const string RessourceUri = "api/projects";

        public ProjectClient(IHttpClient httpClient, IResponseMessageValidator validator)
            : base(httpClient, validator)
        {
        }

        public IEnumerable<Project> GetProjects()
        {
            var responseMessage = HttpClient.Get(string.Format("{0}/{1}", ServerAdress, RessourceUri));
            ValidateResponse(responseMessage);
            return JsonConverter<Project>.CreateList(responseMessage);
        }

        public Project GetProject(int projectId)
        {
            var responseMessage = HttpClient.Get(string.Format("{0}/{1}/{2}", ServerAdress, RessourceUri, projectId));
            ValidateResponse(responseMessage);
            return JsonConverter<Project>.Create(responseMessage);
        }

        public void CreateProject(Project project)
        {
            var content = JsonConverter<Project>.Create(project);
            var responseMessage = HttpClient.Post(string.Format("{0}/{1}", ServerAdress, RessourceUri), content);

            var responseProject = JsonConverter<Project>.Create(responseMessage);
            project.Id = responseProject.Id;

            ValidateResponse(responseMessage);
        }

        public void Update(Project project)
        {
            var content = JsonConverter<Project>.Create(project);
            var responseMessage = HttpClient.Put(string.Format("{0}/{1}/{2}", ServerAdress, RessourceUri, project.Id), content);
            ValidateResponse(responseMessage);
        }

        public void DeleteProject(Project project)
        {
            var responseMessage = HttpClient.Delete(string.Format("{0}/{1}/{2}", ServerAdress, RessourceUri, project.Id));
            ValidateResponse(responseMessage);
        }
    }
}