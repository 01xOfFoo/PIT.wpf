using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using PIT.Business.Entities;
using PIT.Business.Entities.Events.Issues;
using PIT.Business.Filter;
using PIT.Business.Service.Contracts;
using PIT.Core;
using PIT.WPF.Models.Issues;
using PIT.WPF.Models.Loaders.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Contracts;
using PIT.WPF.ViewModels.Issues;

namespace PIT.WPF.Models.Loaders
{
    [Export(typeof(ILoader<IssueViewModel, Issue>))]
    public class IssuesLoader : Loader<IssueViewModel, Issue>, IDisposable
    {
        private readonly Disposer _disposer = new Disposer();
        private readonly IIssueFilter _issueFilter;
        private readonly IssueSelection _issueSelection;
        private readonly ProjectSelection _projectSelection;

        [ImportingConstructor]
        public IssuesLoader(IIssueBusiness business, IViewModelFactory<IssueViewModel, Issue> factory,
            ProjectSelection projectSelection, IssueSelection issueSelection, IIssueFilter issueFilter)
            : base(business, factory)
        {
            _projectSelection = projectSelection;
            _projectSelection.ProjectChanged += (s, e) => Load();

            _disposer.Add(Events.Current.OfType<FilterIssueStatus>().Subscribe(e => OnFilterStatus(e)));

            _issueSelection = issueSelection;
            _issueFilter = issueFilter;
        }

        public void Dispose()
        {
            _disposer.Dispose();
        }

        private void OnFilterStatus(FilterIssueStatus filterIssueStatus)
        {
            Load();
        }

        protected override void SetCollection(ObservableCollection<IssueViewModel> collection)
        {
            _issueSelection.Issues = collection;
        }

        protected override IEnumerable<Issue> GetEntites()
        {
            int id = _projectSelection.SelectedProject.Id;

            IEnumerable<Issue> issues = ((IIssueBusiness) Business).GetIssuesOfProject(id).Select(i => FixUpProjects(i));
            return _issueFilter.Filter(issues);
        }

        private Issue FixUpProjects(Issue issue)
        {
            issue.Project = _projectSelection.SelectedProject.Project;
            return issue;
        }

        public override void Load()
        {
            base.Load();
            Events.Current.Publish(new IssuesLoaded());
        }
    }
}