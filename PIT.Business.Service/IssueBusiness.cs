using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using PIT.API.Clients.Contracts;
using PIT.API.Contracts;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;

namespace PIT.Business.Service
{
    [Export(typeof(IIssueBusiness))]
    public class IssueBusiness : IIssueBusiness
    {
        private readonly IIssueClient _issueClient;

        [ImportingConstructor]
        public IssueBusiness(IClientProvider clientProvider)
        {
            _issueClient = clientProvider.IssueClient;
        }

        public Issue GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Issue> GetAll()
        {
            return _issueClient.GetAll();
        }

        public IEnumerable<Issue> GetIssuesOfProject(int projectId)
        {
            return _issueClient.GetIssuesOfProject(projectId);
        }

        public void Create(Issue entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Issue entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Issue entity)
        {
            throw new NotImplementedException();
        }
    }
}
