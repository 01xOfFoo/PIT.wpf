using System.Collections.ObjectModel;

namespace PIT.WPF.ViewModels.Issues.Contracts
{
    public interface IIssueAreaViewModel
    {
        IIssueHeaderAreaViewModel IssueHeaderView { get; set; }
        ObservableCollection<IssueViewModel> Issues { get; set; }
    }
}
