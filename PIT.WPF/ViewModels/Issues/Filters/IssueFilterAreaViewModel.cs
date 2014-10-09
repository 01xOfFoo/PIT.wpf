using System.ComponentModel.Composition;
using Caliburn.Micro;
using Microsoft.Practices.ServiceLocation;
using PIT.WPF.ViewModels.Issues.Contracts;
using PIT.WPF.ViewModels.Issues.Filters.Contracts;

namespace PIT.WPF.ViewModels.Issues.Filters
{
    [Export(typeof(IIssueFilterAreaViewModel))]
    public class IssueFilterAreaViewModel : Conductor<object>, IIssueFilterAreaViewModel
    {
        public IssueFilterAreaViewModel()
        {
            ActivatePage(ServiceLocator.Current.GetInstance<IIssueAllFiltersAreaViewModel>());
        }

        public object FilterContent { get; set; }

        public void ActivatePage(object content)
        {
            FilterContent = content;
            NotifyOfPropertyChange(() => FilterContent);
            ActivateItem(FilterContent);
        }
    }
}