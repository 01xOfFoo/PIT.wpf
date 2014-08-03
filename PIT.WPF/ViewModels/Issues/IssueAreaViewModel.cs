using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Reactive.Linq;
using System.Windows.Input;
using Caliburn.Micro;
using PIT.Business.Entities;
using PIT.Business.Entities.Events.Issues;
using PIT.Core;
using PIT.WPF.Commands.Issue;
using PIT.WPF.Models.Issues;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Issues.Contracts;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IIssueAreaViewModel))]
    public class IssueAreaViewModel : Screen, IIssueAreaViewModel, IDisposable
    {
        private readonly Disposer _disposer = new Disposer();

        private readonly ICommand _editEditIssueCommand;
        private readonly IIssueCollection _issueCollection;
        private readonly IssueSelection _issueSelection;
        private readonly ProjectSelection _projectSelection;

        [ImportingConstructor]
        public IssueAreaViewModel(IIssueCollection issueCollection, ProjectSelection projectSelection,
            IssueSelection issueSelection, EditIssueCommand editEditIssueCommand)
        {
            _issueSelection = issueSelection;
            _editEditIssueCommand = editEditIssueCommand;

            _issueCollection = issueCollection;
            Issues = _issueCollection.Items;

            _projectSelection = projectSelection;
            _projectSelection.ProjectChanged += OnProjectChanged;
            _disposer.Add(Events.Current.OfType<IssueStatusFiltered>().Subscribe(e => OnIssueStatusFilterChanged()));
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
            _disposer.Dispose();
        }

        [Import]
        public IIssueHeaderAreaViewModel IssueHeader { get; set; }

        public ObservableCollection<IssueViewModel> Issues { get; set; }

        private void OnIssueStatusFilterChanged()
        {
            LoadIssuesOfCurrentProject();
        }

        private void LoadIssuesOfCurrentProject()
        {
            LoadIssues(_projectSelection.SelectedProject.Project);
        }

        private void OnProjectChanged(object sender, ProjectViewModel projectViewModel)
        {
            LoadIssues(projectViewModel.Project);
        }

        private void LoadIssues(Project project)
        {
            _issueCollection.Load(project);
        }

        private void OnIssuesLoaded()
        {
            NotifyOfPropertyChange(() => Issues);
        }

        public void OnIssueDoubleClicked()
        {
            if (_issueSelection.SelectedIssue != null)
                EditIssue.Execute(null);
        }
    }
}