using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.ViewModels.Issues;

namespace PIT.WPF.Models.Issues
{
    [Export(typeof(IIssueSelection))]
    [Export(typeof(IssueSelection))]
    public class IssueSelection : IIssueSelection
    {
        private IssueViewModel _selectedIssue;
        private ObservableCollection<IssueViewModel> _issues;

        public IssueSelection()
        {
            _issues = new ObservableCollection<IssueViewModel>();
        }

        public IssueViewModel SelectedIssue
        {
            get { return _selectedIssue; }
            set
            {
                _selectedIssue = value;
                NotifyOfIssueChanged(_selectedIssue);
            }
        }

        public ObservableCollection<IssueViewModel> Issues
        {
            get { return _issues; }
        }

        public event EventHandler IssueChanged;

        private void NotifyOfIssueChanged(IssueViewModel issueViewModel)
        {
            if ((IssueChanged != null) && (issueViewModel != null))
            {
                IssueChanged(issueViewModel, EventArgs.Empty);
            }
        }

        public event NotifyCollectionChangedEventHandler IssuesUpdates;
    }
}