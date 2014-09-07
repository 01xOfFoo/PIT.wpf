using System.ComponentModel.Composition;
using PIT.Business.Entities.Events.Issues;
using PIT.Business.Service.Contracts;
using PIT.Core;
using PIT.WPF.Models.Issues;

namespace PIT.WPF.Commands.Issue
{
    [Export]
    public class DeleteIssueCommand : Command
    {
        private readonly IIssueBusiness _business;
        private readonly IssueSelection _selection;

        [ImportingConstructor]
        public DeleteIssueCommand(IIssueBusiness business, IssueSelection selection)
        {
            _business = business;
            _selection = selection;
        }

        public override void Execute(object parameter)
        {
            var issue = _selection.SelectedIssue.Issue;
            _business.Delete(issue);
            Events.Current.Publish(new IssueDeleted(issue));
        }
    }
}