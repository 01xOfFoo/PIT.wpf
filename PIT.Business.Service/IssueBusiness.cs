using System.Collections.Generic;
using System.ComponentModel.Composition;
using PIT.API.Clients.Contracts;
using PIT.API.Contracts;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;

namespace PIT.Business.Service
{
    [Export(typeof(IIssueBusiness))]
    public class IssueBusiness : Business<Issue>, IIssueBusiness
    {
        [ImportingConstructor]
        public IssueBusiness(IClientProvider provider)
            : base(provider.IssueClient)
        {
        }

        public IEnumerable<Issue> GetIssuesOfProject(int projectId)
        {
            return ((IIssueClient) Client).GetIssuesOfProject(projectId);
        }
    }
}