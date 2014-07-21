using System.Collections.Generic;
using PIT.API.Clients.Contracts;
using PIT.API.HTTP;
using PIT.API.Validators.Contracts;
using PIT.Business.Entities;

namespace PIT.API.Clients
{
    public class IssueClient : BaseClient, IIssueClient
    {
        public IssueClient(IHttpClient httpClient, IResponseMessageValidator validator)
            : base(httpClient, validator)
        {
        }

        public Issue GetIssue(int issueId)
        {
            var responseMessage = HttpClient.Get(string.Format("{0}/{1}/{2}", ServerAdress, "api/issues", issueId));
            ValidateResponse(responseMessage);
            return JsonConverter<Issue>.Create(responseMessage);
        }

        public IEnumerable<Issue> GetIssues()
        {
            var responseMessage = HttpClient.Get(string.Format("{0}/{1}", ServerAdress, "api/issues"));
            ValidateResponse(responseMessage);
            return JsonConverter<Issue>.CreateList(responseMessage);
        }

        public IEnumerable<Issue> GetIssuesOfProject(int projectId)
        {
            var responseMessage = HttpClient.Get(string.Format("{0}/{1}?{2}={3}", ServerAdress, "api/issues", "projectid", projectId));
            ValidateResponse(responseMessage);
            return JsonConverter<Issue>.CreateList(responseMessage);
        }
    }
}