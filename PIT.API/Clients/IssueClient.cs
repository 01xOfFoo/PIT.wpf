using System.Collections.Generic;
using PIT.API.Clients.Contracts;
using PIT.API.HTTP;
using PIT.API.Validators.Contracts;
using PIT.Business.Entities;

namespace PIT.API.Clients
{
    public class IssueClient : Client<Issue>, IIssueClient
    {
        public IssueClient(IHttpClient httpClient, IResponseMessageValidator validator)
            : base(httpClient, validator)
        {
            RessourceUri = "api/issues";
        }

        public IEnumerable<Issue> GetIssuesOfProject(int projectId)
        {
            var responseMessage = HttpClient.Get(string.Format("{0}/{1}?{2}={3}", ServerAdress, RessourceUri, "projectid", projectId));
            ValidateResponse(responseMessage);
            return JsonConverter<Issue>.CreateList(responseMessage);
        }
    }
}