using System.Collections.Generic;
using PIT.Business.Entities;

namespace PIT.API.Clients.Contracts
{
    public interface IIssueClient
    {
        Issue GetIssue(int issueId);
        IEnumerable<Issue> GetIssues();
        IEnumerable<Issue> GetIssuesOfProject(int projectId);
    }
}