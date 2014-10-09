using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Issues.Filters;

namespace PIT.WPF.SampleData.Issues.Filters
{
    [ExcludeFromCodeCoverage]
    public class SampleIssueStatusFilterViewModel
    {
        private ICollection<IssueStatusViewModel> _statuses;

        public ICollection<IssueStatusViewModel> Statuses
        {
            get
            {
                return _statuses ?? (
                    _statuses = new Collection<IssueStatusViewModel>(
                        Enum.GetValues(typeof(IssueStatus))
                            .Cast<IssueStatus>()
                            .Select(s => new IssueStatusViewModel(s))
                            .ToList()
                        )
                    );
            }
        }
    }
}