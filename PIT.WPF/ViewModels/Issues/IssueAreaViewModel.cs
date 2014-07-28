using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using Caliburn.Micro;
using PIT.Business.Service.Contracts;
using PIT.WPF.Commands.Issue;
using PIT.WPF.Models.Issues;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Issues.Contracts;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.Views.Issues;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IIssueAreaViewModel))]
    public class IssueAreaViewModel : Screen, IIssueAreaViewModel, IDisposable
    {
        private readonly ICommand _editEditIssueCommand;
        private readonly IIssueBusiness _issueBusiness;
        private readonly IssueSelection _issueSelection;
        private readonly ProjectSelection _projectSelection;

        [ImportingConstructor]
        public IssueAreaViewModel(IIssueHeaderAreaViewModel issueHeaderAreaView, IIssueBusiness issueBusiness,
            ProjectSelection projectSelection, IssueSelection issueSelection, EditIssueCommand editEditIssueCommand)
        {
            IssueHeaderView = issueHeaderAreaView;
            _issueBusiness = issueBusiness;
            _editEditIssueCommand = editEditIssueCommand;

            _projectSelection = projectSelection;
            _projectSelection.ProjectChanged += OnProjectChanged;

            _issueSelection = issueSelection;
        }

        public IssueViewModel Issue
        {
            get { return _issueSelection.SelectedIssue; }
            set { _issueSelection.SelectedIssue = value; }
        }

        public ICommand EditIssue
        {
            get { return _editEditIssueCommand; }
        }

        public void Dispose()
        {
            _projectSelection.ProjectChanged -= OnProjectChanged;
        }

        public IIssueHeaderAreaViewModel IssueHeaderView { get; set; }

        public ObservableCollection<IssueViewModel> Issues
        {
            get { return _issueSelection.Issues; }
            set { throw new NotImplementedException(); }
        }

        private void OnProjectChanged(object sender, EventArgs e)
        {
            var project = (ProjectViewModel) sender;
            LoadIssues(project);
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount != 2)
                return;
            EditIssue.Execute(null);
        }

        protected override void OnViewAttached(object view, object context)
        {
            var issueAreaView = (IssueAreaView) view;
            issueAreaView.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
        }

        private void LoadIssues(ProjectViewModel projectViewModel)
        {
            _issueSelection.Issues.Clear();
            foreach (
                IssueViewModel issueViewModel in
                    _issueBusiness.GetIssuesOfProject(projectViewModel.Id)
                                  .Select(issue => 
                                      new IssueViewModel()
                                      {
                                          Issue = issue
                                      }))
            {
                issueViewModel.Issue.Project = projectViewModel.Project;
                _issueSelection.Issues.Add(issueViewModel);
            }
            NotifyOfPropertyChange(() => Issues);
        }
    }
}