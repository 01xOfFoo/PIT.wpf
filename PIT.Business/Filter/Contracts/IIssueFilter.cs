using System;
using System.Collections.Generic;
using PIT.Business.Entities;

namespace PIT.Business.Filter.Contracts
{
    public interface IIssueFilter
    {
        IEnumerable<Issue> Filter(IEnumerable<Issue> issues);
        bool Absorb(Issue issue);
        void AddFilter(IssueStatus status);
        void RemoveFilter(IssueStatus status);
    }
}