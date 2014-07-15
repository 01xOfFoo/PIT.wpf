using PIT.WPF.Commands;

namespace PIT.WPF.ViewModels.Issues.Contracts
{
    public interface IIssueHeaderAreaViewModel
    {
        AddIssueCommand AddIssueCommand { get; }
    }
}