using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using PIT.Business.Service.Contracts;
using PIT.WPF.Helpers.Contracts;
using PIT.WPF.ViewModels.Issues.Contracts;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IIssueAreaViewModel))]
    public class IssueAreaViewModel : PropertyChangedBase, IIssueAreaViewModel, IDisposable
    {
        private readonly IProjectSelector _projectSelector;
        private readonly IIssueBusiness _issueBusiness;

        public IIssueHeaderAreaViewModel IssueHeaderView { get; set; }
        
        private ObservableCollection<IssueViewModel> _issues;
        public ObservableCollection<IssueViewModel> Issues 
        {
            get
            {
                return _issues;
            }
            set
            {
                _issues = value;
                NotifyOfPropertyChange(() => Issues);
            }
        }

        [ImportingConstructor]
        public IssueAreaViewModel(IIssueHeaderAreaViewModel issueHeaderAreaView, IIssueBusiness issueBusiness, IProjectSelector projectSelector)
        {
            IssueHeaderView = issueHeaderAreaView;
            _issueBusiness = issueBusiness;

            _projectSelector = projectSelector;
            _projectSelector.ProjectChanged += OnProjectChanged;
        }

        private void OnProjectChanged(object sender, EventArgs e)
        {
            var project = (ProjectViewModel)sender;
            LoadIssues(project);
        }

        private void LoadIssues(ProjectViewModel projectViewModel)
        {
            var iss = (from issue in _issueBusiness.GetIssuesOfProject(projectViewModel.Id)
                       select new IssueViewModel(issue)).ToList();

            Issues = new ObservableCollection<IssueViewModel>(iss);
        }

        public void Dispose()
        {
            _projectSelector.ProjectChanged -= OnProjectChanged;
        }
    }
}
