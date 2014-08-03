using System;
using System.Collections.ObjectModel;
using System.Linq;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Issues;

namespace PIT.WPF.SampleData
{
    public class SampleIssueStatusFilterViewModel
    {
        public SampleIssueStatusFilterViewModel()
        {
            var stati = Enum.GetValues(typeof(IssueStatus))
                .Cast<IssueStatus>()
                .Select(s => new IssueStatusViewModel(s));

            Statuses = new ObservableCollection<IssueStatusViewModel>(stati);
        }

        public ObservableCollection<IssueStatusViewModel> Statuses { get; set; }
    }
}