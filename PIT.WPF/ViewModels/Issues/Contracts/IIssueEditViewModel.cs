namespace PIT.WPF.ViewModels.Issues.Contracts
{
    public interface IIssueEditViewModel
    {
        void ActivateIssue(IssueViewModel issueViewModel);
        void SaveIssue();
    }
}
