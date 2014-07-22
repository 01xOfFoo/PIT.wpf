using System.Collections.Generic;
using PIT.Business.Entities;

namespace PIT.API.Clients.Contracts
{
    public interface IIssueClient : IClient<Issue>
    {
        IEnumerable<Issue> GetIssuesOfProject(int projectId);
    }
}