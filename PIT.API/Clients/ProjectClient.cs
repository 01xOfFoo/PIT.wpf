using PIT.API.Clients.Contracts;
using PIT.API.HTTP;
using PIT.API.Validators.Contracts;
using PIT.Business.Entities;

namespace PIT.API.Clients
{
    public class ProjectClient : Client<Project>, IProjectClient
    {
        public ProjectClient(IHttpClient httpClient, IResponseMessageValidator validator)
            : base(httpClient, validator)
        {
            RessourceUri = "api/projects";
        }
    }
}