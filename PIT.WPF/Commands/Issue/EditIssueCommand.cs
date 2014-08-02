using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.Business;
using PIT.Business.Filter.Contracts;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Issues;
using PIT.WPF.ViewModels.Issues;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.Commands.Issue
{
    [Export]
    public class EditIssueCommand : Command
    {
        private readonly IIssueBusiness _issueBusiness;
        private readonly IIssueEditViewModel _issueEditViewModel;
        private readonly IIssueFilter _issueFilter;
        private readonly IssueSelection _issueSelection;
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public EditIssueCommand(IWindowManager windowManager, IIssueBusiness issueBusiness,
            IIssueFilter issueFilter, IssueSelection issueSelection, IIssueEditViewModel issueEditViewModel)
        {
            _windowManager = windowManager;
            _issueBusiness = issueBusiness;
            _issueFilter = issueFilter;
            _issueSelection = issueSelection;
            _issueEditViewModel = issueEditViewModel;
        }

        public override void Execute(object parameter)
        {
            var issue = _issueSelection.SelectedIssue;
            var history = new EntityHistory<IssueViewModel>(issue);

            bool? result = _windowManager.ShowDialog(_issueEditViewModel);
            if (result != null && result == true)
            {
                _issueBusiness.Update(_issueSelection.SelectedIssue.Issue);
                if (history.ValueChanged("Status") && _issueFilter.Absorb(issue.Issue))
                    _issueSelection.Issues.Remove(issue);
            }
            else
            {
                history.Restore();
            }
        }
    }
}