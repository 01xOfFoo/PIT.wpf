using PIT.WPF.Commands;
using PIT.WPF.Commands.Issue;

namespace PIT.WPF.ViewModels.Issues.Contracts
{
    public interface IIssueHeaderAreaViewModel
    {
        AddIssueCommand AddIssueCommand { get; }
    }
}