using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using PIT.Business.Entities;
using PIT.Business.Entities.Events.Issues;
using PIT.Business.Filter.Contracts;
using PIT.Core;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof (IIssueStatusFilterViewModel))]
    public class IssueStatusFilterViewModel : Screen, IIssueStatusFilterViewModel
    {
        private readonly IIssueFilter _filter;

        [ImportingConstructor]
        public IssueStatusFilterViewModel(IIssueFilter filter)
        {
            _filter = filter;
            LoadIssues();
            Statuses.CollectionItemPropertyChanged += OnCollectionItemPropertyChanged;
        }

        public ObservableCollectionEx<IssueStatusViewModel> Statuses { get; private set; }

        public string DisplayText
        {
            get
            {
                string text = string.Join(", ", Statuses.Where(i => i.IsSelected).Select(i => i.Text));
                if (text.Length >= 20)
                    text = text.Substring(0, 18) + "..";

                return text.Equals("") ? "Status: All" : text;
            }
        }

        public bool ClearFiltersVisible
        {
            get { return Statuses.Any(s => s.IsSelected); }
        }

        public void ClearAllFilters()
        {
            Statuses.ForEach(s => s.IsSelected = false);
        }

        public void LoadIssues()
        {
            var stati = Enum.GetValues(typeof (IssueStatus))
                .Cast<IssueStatus>()
                .Select(s => new IssueStatusViewModel(s));

            Statuses = new ObservableCollectionEx<IssueStatusViewModel>();
            stati.ForEach(s => Statuses.Add(s));
        }

        private void OnCollectionItemPropertyChanged(object sender, IssueStatusViewModel issueStatusViewModel)
        {
            DetermineFilterAction(issueStatusViewModel);
            Events.Current.Publish(new IssueStatusFiltered(issueStatusViewModel.Status));

            NotifyOfPropertyChange(() => ClearFiltersVisible);
            NotifyOfPropertyChange(() => DisplayText);
        }

        private void DetermineFilterAction(IssueStatusViewModel issueStatusViewModel)
        {
            if (issueStatusViewModel.IsSelected)
                _filter.AddFilter(issueStatusViewModel.Status);
            else
                _filter.RemoveFilter(issueStatusViewModel.Status);
        }
    }
}