using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.Business;
using PIT.WPF.Models.Issues;
using PIT.WPF.ViewModels.Issues;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.Commands.Issue
{
    [Export]
    public class EditIssueCommand : Command
    {
        private readonly IIssueEditViewModel _issueEditViewModel;
        private readonly IssueSelection _issueSelection;
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public EditIssueCommand(IssueSelection issueSelection, IWindowManager windowManager,
            IIssueEditViewModel issueEditViewModel)
        {
            _issueSelection = issueSelection;
            _windowManager = windowManager;
            _issueEditViewModel = issueEditViewModel;
        }

        public override void Execute(object parameter)
        {
            var history = new EntityHistory<IssueViewModel>(_issueSelection.SelectedIssue);

            bool? result = _windowManager.ShowDialog(_issueEditViewModel);
            if (result != null && result == false)
            { 
                history.Restore();
            }
        }
    }
}