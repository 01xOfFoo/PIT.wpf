using System.ComponentModel.Composition;

namespace PIT.WPF.Commands.Issue
{
    public interface IIssueCommands
    {
        [Import]
        EditIssueCommand EditIssue { get; set; }

        [Import]
        DeleteIssueCommand DeleteIssue { get; set; }
    }
}