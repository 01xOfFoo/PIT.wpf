using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using PIT.Business.Entities;
using PIT.Business.Entities.Events.Issues;
using PIT.Business.Filter.Contracts;
using PIT.Core;

namespace PIT.Business.Filter
{
    [Export(typeof(IIssueFilter))]
    public class IssueFilter : IIssueFilter
    {
        private readonly List<IssueStatus> _filters = new List<IssueStatus>();

        public IssueFilter()
        {
        }

        public IEnumerable<Issue> Filter(IEnumerable<Issue> issues)
        {
            IEnumerable<Issue> filteredIssues = issues;
            if (_filters.Any())
                filteredIssues = filteredIssues.Where(i => _filters.Contains(i.Status));

            return filteredIssues;
        }

        public bool Absorb(Issue issue)
        {
            return !_filters.Any() | !_filters.Contains(issue.Status);
        }

        public void AddFilter(IssueStatus status)
        {
            _filters.Add(status);
        }

        public void RemoveFilter(IssueStatus status)
        {
            _filters.Remove(status);
        }
    }
}