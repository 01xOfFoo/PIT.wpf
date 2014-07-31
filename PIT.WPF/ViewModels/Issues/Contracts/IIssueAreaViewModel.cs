using System.Collections.ObjectModel;

namespace PIT.WPF.ViewModels.Issues.Contracts
{
    public interface IIssueAreaViewModel
    {
        IIssueHeaderAreaViewModel IssueHeader { get; set; }
        ObservableCollection<IssueViewModel> Issues { get; set; }
    }
}