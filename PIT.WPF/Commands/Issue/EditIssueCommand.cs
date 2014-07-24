using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.Models.Issues;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.Commands.Issue
{
    [Export]
    public class EditIssueCommand : Command
    {
        private readonly IssueSelection _issueSelection;
        private readonly IWindowManager _windowManager;
        private readonly IIssueEditViewModel _issueEditViewModel;

        [ImportingConstructor]
        public EditIssueCommand(IssueSelection issueSelection, IWindowManager windowManager, IIssueEditViewModel issueEditViewModel)
        {
            _issueSelection = issueSelection;
            _windowManager = windowManager;
            _issueEditViewModel = issueEditViewModel;
        }

        public override void Execute(object parameter)
        {
            _issueEditViewModel.ActivateIssue(_issueSelection.SelectedIssue);
            _windowManager.ShowDialog(_issueEditViewModel);
        }
    }
}