using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using PIT.Business.Entities;
using PIT.Business.Entities.Events.Issues;
using PIT.Core;

namespace PIT.Business.Filter
{
    [Export(typeof(IIssueFilter))]
    public class IssueFilter : IIssueFilter
    {
        private readonly Disposer _disposer = new Disposer();
        private readonly List<IssueStatus> _filters = new List<IssueStatus>();

        public IssueFilter()
        {
            _disposer.Add(Events.Current.OfType<FilterIssueStatus>().Subscribe(e => OnIsseStatusFiltered(e)));
        }

        public IEnumerable<Issue> Filter(IEnumerable<Issue> issues)
        {
            IEnumerable<Issue> filteredIssues = issues;
            if (_filters.Any())
                filteredIssues = filteredIssues.Where(i => _filters.Contains(i.Status));

            return filteredIssues;
        }

        public void Absorb(Issue issue, Action addFunc)
        {
            if (_filters.Any() && _filters.Contains(issue.Status))
                addFunc();
        }

        private void OnIsseStatusFiltered(FilterIssueStatus filterIssueStatus)
        {
            if (filterIssueStatus.Filter)
                _filters.Add(filterIssueStatus.Status);
            else
                _filters.Remove(filterIssueStatus.Status);
        }
    }

    public interface IIssueFilter
    {
        IEnumerable<Issue> Filter(IEnumerable<Issue> issues);
        void Absorb(Issue issue, Action addFunc);
    }
}