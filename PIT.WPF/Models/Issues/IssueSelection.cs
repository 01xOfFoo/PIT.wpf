using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using PIT.WPF.Models.Issues.Contracts;
using PIT.WPF.ViewModels.Issues;

namespace PIT.WPF.Models.Issues
{
    [Export(typeof(IIssueSelection))]
    [Export(typeof(IssueSelection))]
    public class IssueSelection : IIssueSelection
    {
        private IssueViewModel _selectedIssue;

        public IssueSelection()
        {
            Issues = new ObservableCollection<IssueViewModel>();
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

        public ObservableCollection<IssueViewModel> Issues { get; set; }

        public event EventHandler<IssueViewModel> IssueChanged;

        private void NotifyOfIssueChanged(IssueViewModel issueViewModel)
        {
            if (IssueChanged != null) 
            {
                IssueChanged(this, issueViewModel);
            }
        }
    }
}