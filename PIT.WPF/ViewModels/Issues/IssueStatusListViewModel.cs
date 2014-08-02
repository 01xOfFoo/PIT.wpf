using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls.Primitives;
using PIT.Business.Entities;
using PIT.Business.Entities.Events.Issues;
using PIT.Business.Filter.Contracts;
using PIT.Core;
using PIT.WPF.Models.Loaders;
using PIT.WPF.Models.Loaders.Contracts;

namespace PIT.WPF.ViewModels.Issues
{
    [Export]
    public class IssueStatusListViewModel : ObservableCollectionEx<IssueStatusViewModel>
    {
        private readonly ILoader<IssueViewModel, Issue> _issuesLoader;
        private readonly IIssueFilter _filter;

        [ImportingConstructor]
        public IssueStatusListViewModel(ILoader<IssueViewModel, Issue> issuesLoader, IIssueFilter filter)
        {
            _issuesLoader = issuesLoader;
            _filter = filter;
        }

        public string DisplayText
        {
            get
            {
                IEnumerable<IssueStatusViewModel> vms = Items.Where(i => i.IsSelected);
                switch (vms.Count())
                {
                    case 0:
                        return "Status: All";
                    case 1:
                        return "Status: " + vms.FirstOrDefault().Text;
                    default:
                        return "Status: *";
                }
            }
            private set { throw new NotImplementedException(); }
        }

        public override void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var status = ((IssueStatusViewModel) sender);
            if (status.IsSelected)
                _filter.AddFilter(status.Status);
            else
                _filter.RemoveFilter(status.Status);

            _issuesLoader.Load();
            if (e.PropertyName == "IsSelected")
                OnPropertyChanged(new PropertyChangedEventArgs("DisplayText"));
        }
    }
}