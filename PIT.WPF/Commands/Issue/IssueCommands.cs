using System.ComponentModel.Composition;

namespace PIT.WPF.Commands.Issue
{
    [Export(typeof(IIssueCommands))]
    public class IssueCommands : IIssueCommands
    {
        [Import]
        public EditIssueCommand EditIssue { get; set; }

        [Import]
        public DeleteIssueCommand DeleteIssue { get; set; }
    }
}