using System.Collections.Generic;
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
    }
}