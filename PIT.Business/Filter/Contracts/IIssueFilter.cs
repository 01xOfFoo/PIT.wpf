using PIT.Business.Entities;

namespace PIT.Business.Filter.Contracts
{
    public interface IIssueFilter
    {
        bool Match(Issue issue);
        void AddFilter(IssueStatus status);
        void RemoveFilter(IssueStatus status);
    }
}