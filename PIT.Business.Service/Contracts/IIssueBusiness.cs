using System.Collections.Generic;
using PIT.Business.Entities;

namespace PIT.Business.Service.Contracts
{
    public interface IIssueBusiness : IBusiness<Issue>
    {
        IEnumerable<Issue> GetIssuesOfProject(int projectId);
    }
}
