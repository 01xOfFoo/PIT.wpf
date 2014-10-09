using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PIT.WPF.ViewModels.Issues.Filters;

namespace PIT.WPF.SampleData.Issues.Filters
{
    internal class SampleIssueAllFiltersAreaViewModel
    {
        private readonly ICollection<FilterViewModel> _filters = new Collection<FilterViewModel>();

        public SampleIssueAllFiltersAreaViewModel()
        {
            _filters.Add(new IssueStatusFilterAreaViewModel());
            _filters.Add(new IssueStatusFilterAreaViewModel());
        }

        public ICollection<FilterViewModel> Filters
        {
            get { return _filters; }
            set { throw new NotImplementedException(); }
        }
    }
}