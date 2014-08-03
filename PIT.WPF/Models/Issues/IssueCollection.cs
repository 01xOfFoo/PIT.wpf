using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using PIT.Business.Entities;
using PIT.Business.Filter.Contracts;
using PIT.Business.Service.Contracts;
using PIT.Core;
using PIT.WPF.ViewModels.Contracts;
using PIT.WPF.ViewModels.Issues;

namespace PIT.WPF.Models.Issues
{
    [Export(typeof(IIssueCollection))]
    public class IssueCollection : IIssueCollection, IDisposable
    {
        private readonly Disposer _disposer = new Disposer();
        private readonly IViewModelFactory<IssueViewModel, Issue> _factory;
        private readonly IIssueFilter _filter;
        private readonly IIssueBusiness _service;

        [ImportingConstructor]
        public IssueCollection(IIssueFilter filter, IIssueBusiness service,
            IViewModelFactory<IssueViewModel, Issue> factory)
        {
            _filter = filter;
            _service = service;
            _factory = factory;

            Items = new ObservableCollection<IssueViewModel>();

            _disposer.Add(Events.Current.OfType<Issue>().Subscribe(i => OnIssueUpdate(i)));
        }

        public void Dispose()
        {
            _disposer.Dispose();
        }

        public ObservableCollection<IssueViewModel> Items { get; private set; }

        public void Load(Project project)
        {
            Items.Clear();

            var issues = _service.GetIssuesOfProject(project.Id);
            foreach (var issue in issues.Where(issue => _filter.Match(issue)))
            {
                issue.Project = project;
                Items.Add(_factory.CreateViewModel(issue));
            }
        }

        private void OnIssueUpdate(Issue issue)
        {
            DetermineAction(issue);
        }

        private void DetermineAction(Issue issue)
        {
            var flag1 = IsInList(issue);
            var flag2 = MatchesFilter(issue);

            if (flag1 && !flag2)
                RemoveIssueFromList(issue);
            else if (!flag1 && flag2)
                AddIssueToList(issue);
        }

        private void AddIssueToList(Issue issue)
        {
            Items.Add(_factory.CreateViewModel(issue));
        }

        private void RemoveIssueFromList(Issue issue)
        {
            Items.Remove(Items.FirstOrDefault(i => i.Issue == issue));
        }

        private bool MatchesFilter(Issue issue)
        {
            return _filter.Match(issue);
        }

        private bool IsInList(Issue issue)
        {
            return Items.Any(i => i.Issue == issue);
        }
    }
}