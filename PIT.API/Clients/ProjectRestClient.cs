using PIT.API.Clients.Contracts;
using PIT.API.HTTP.Contracts;
using PIT.Business.Entities;

namespace PIT.API.Clients
{
    public class ProjectRestClient : RestClient<Project>, IProjectClient
    {
        public ProjectRestClient(IHttpClient httpClient, IResponseMessageValidator validator)
            : base(httpClient, validator)
        {
            RessourceUri = "api/projects";
        }
    }
}