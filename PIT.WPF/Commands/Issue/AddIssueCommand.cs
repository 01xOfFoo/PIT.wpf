using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Issues;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.Commands.Issue
{
    [Export]
    public class AddIssueCommand : Command
    {
        private readonly IIssueEditViewModel _issueEditViewModel;
        private readonly IIssueViewModelFactory _issueViewModelFactory;
        private readonly ProjectSelection _projectSelection;
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public AddIssueCommand(IWindowManager windowManager, ProjectSelection projectSelection,
            IIssueViewModelFactory issueViewModelFactory, IIssueEditViewModel issueEditViewModel)
        {
            _windowManager = windowManager;
            _projectSelection = projectSelection;
            _issueViewModelFactory = issueViewModelFactory;
            _issueEditViewModel = issueEditViewModel;
        }

        public override void Execute(object parameter)
        {
            IssueViewModel issue = _issueViewModelFactory.CreateIssueViewModel();
            issue.Issue.Project = _projectSelection.SelectedProject.Project;
            _windowManager.ShowDialog(_issueEditViewModel);
        }
    }
}