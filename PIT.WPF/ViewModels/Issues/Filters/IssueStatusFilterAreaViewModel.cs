using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using PIT.Business.Entities;

namespace PIT.WPF.ViewModels.Issues.Filters
{
    [Export(typeof(FilterViewModel))]
    internal class IssueStatusFilterAreaViewModel : FilterViewModel
    {
        private readonly Collection<IssueStatusViewModel> _statuses;

        public IssueStatusFilterAreaViewModel() : base("Status")
        {
            _statuses = new Collection<IssueStatusViewModel>(
                Enum.GetValues(typeof(IssueStatus))
                    .Cast<IssueStatus>()
                    .Select(s => new IssueStatusViewModel(s))
                    .ToList()
                );
        }
    }
}