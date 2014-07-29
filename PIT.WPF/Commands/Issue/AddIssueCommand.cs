using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Issues;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Contracts;
using PIT.WPF.ViewModels.Issues;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.Commands.Issue
{
    [Export]
    public class AddIssueCommand : Command
    {
        private readonly IIssueBusiness _issueBusiness;
        private readonly IIssueEditViewModel _issueEditViewModel;
        private readonly IssueSelection _issueSelection;
        private readonly IViewModelFactory<IssueViewModel, Business.Entities.Issue> _issueViewModelFactory;
        private readonly ProjectSelection _projectSelection;
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public AddIssueCommand(IWindowManager windowManager, IIssueBusiness issueBusiness, IssueSelection issueSelection,
            ProjectSelection projectSelection, IIssueEditViewModel issueEditViewModel,
            IViewModelFactory<IssueViewModel, Business.Entities.Issue> issueViewModelFactory)
        {
            _windowManager = windowManager;
            _issueBusiness = issueBusiness;
            _issueSelection = issueSelection;
            _projectSelection = projectSelection;
            _issueViewModelFactory = issueViewModelFactory;
            _issueEditViewModel = issueEditViewModel;
        }

        public override void Execute(object parameter)
        {
            IssueViewModel oldIssue = _issueSelection.SelectedIssue;

            IssueViewModel issue = _issueViewModelFactory.CreateViewModel(null);
            issue.Issue.Project = _projectSelection.SelectedProject.Project;

            _issueSelection.SelectedIssue = issue;

            bool? result = _windowManager.ShowDialog(_issueEditViewModel);
            if (result != null && result == true)
            {
                _issueBusiness.Create(issue.Issue);
                _issueSelection.Issues.Add(issue);
            }
            else
            {
                _issueSelection.SelectedIssue = oldIssue;
            }
        }
    }
}