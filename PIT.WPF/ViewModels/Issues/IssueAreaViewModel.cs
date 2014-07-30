using System;
using System.Collections.Generic;
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
using PIT.WPF.Models.Loaders.Contracts;
using PIT.WPF.ViewModels.Issues.Contracts;
using PIT.WPF.Views.Issues;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IIssueAreaViewModel))]
    public class IssueAreaViewModel : Screen, IIssueAreaViewModel, IDisposable
    {
        private readonly Disposer _disposer = new Disposer();
        
        private readonly ICommand _editEditIssueCommand;
        private readonly ILoader<IssueViewModel, Issue> _issueLoader;
        private readonly IssueSelection _issueSelection;

        [ImportingConstructor]
        public IssueAreaViewModel(ILoader<IssueViewModel, Issue> issueLoader,
            IssueSelection issueSelection, EditIssueCommand editEditIssueCommand)
        {
            _editEditIssueCommand = editEditIssueCommand;
            _issueLoader = issueLoader;

            _issueSelection = issueSelection;
            _disposer.Add(Events.Current.OfType<IssuesLoaded>().Subscribe(e => OnIssuesLoaded(e)));
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

        [Import]
        public IIssueHeaderAreaViewModel IssueHeaderView { get; set; }

        public ObservableCollection<IssueViewModel> Issues
        {
            get { return _issueSelection.Issues; }
            set { throw new NotImplementedException(); }
        }

        private void OnIssuesLoaded(IssuesLoaded issuesLoaded)
        {
            NotifyOfPropertyChange(() => Issues);
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

        public void Dispose()
        {
            _disposer.Dispose();
        }
    }
}