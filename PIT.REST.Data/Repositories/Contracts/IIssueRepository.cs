using System.Linq;
using PIT.REST.Data.Entities;

namespace PIT.REST.Data.Repositories.Contracts
{
    public interface IIssueRepository
    {
        IQueryable<Issue> GetAllIssues();
        Issue GetIssue(int issueId);
        Issue Create(Issue issue);
        Issue Update(Issue issue);
        void Delete(int issueId);
    }
}