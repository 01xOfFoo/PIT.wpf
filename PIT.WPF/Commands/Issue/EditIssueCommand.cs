using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.Business;
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
        private readonly IssueSelection _issueSelection;
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public EditIssueCommand(IWindowManager windowManager, IIssueBusiness issueBusiness,
            IssueSelection issueSelection, IIssueEditViewModel issueEditViewModel)
        {
            _windowManager = windowManager;
            _issueBusiness = issueBusiness;
            _issueSelection = issueSelection;
            _issueEditViewModel = issueEditViewModel;
        }

        public override void Execute(object parameter)
        {
            var history = new EntityHistory<IssueViewModel>(_issueSelection.SelectedIssue);

            bool? result = _windowManager.ShowDialog(_issueEditViewModel);
            if (result != null && result == true)
            {
                _issueBusiness.Update(_issueSelection.SelectedIssue.Issue);
            }
            else
            {
                history.Restore();
            }
        }
    }
}