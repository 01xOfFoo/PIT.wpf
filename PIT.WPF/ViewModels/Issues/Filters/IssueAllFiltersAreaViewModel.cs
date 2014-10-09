using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.Filters.Contracts;
using PIT.WPF.ViewModels.Issues.Contracts;
using PIT.WPF.ViewModels.Issues.Filters.Contracts;

namespace PIT.WPF.ViewModels.Issues.Filters
{
    [Export(typeof(IIssueAllFiltersAreaViewModel))]
    public class IssueAllFiltersAreaViewModel : Screen, IIssueAllFiltersAreaViewModel
    {
        private readonly IReadOnlyCollection<FilterViewModel> _filters;

        [ImportingConstructor]
        public IssueAllFiltersAreaViewModel(IFiltersViewModelProvider filtersProvider)
        {
            _filters = filtersProvider.Provide();
            NotifyOfPropertyChange(() => Filters);
        }

        public IReadOnlyCollection<FilterViewModel> Filters
        {
            get { return _filters; }
        }

    }
}