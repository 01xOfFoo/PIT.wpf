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

        public bool Match(Issue issue)
        {
            if (!_filters.Any())
            {
                return true;
            }
            else
            {
                return _filters.Contains(issue.Status);
            }
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