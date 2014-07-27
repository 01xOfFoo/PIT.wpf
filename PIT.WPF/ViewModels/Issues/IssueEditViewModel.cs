using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Issues;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IIssueEditViewModel))]
    public class IssueEditViewModel : Screen, IIssueEditViewModel
    {
        private readonly IIssueBusiness _issueBusiness;
        private readonly IssueSelection _issueSelection;
        private Window _attachedView;
        private IssueViewModel _issueViewModel;

        [ImportingConstructor]
        public IssueEditViewModel(IIssueBusiness issueBusiness, IssueSelection issueSelection)
        {
            _issueBusiness = issueBusiness;
            _issueSelection = issueSelection;
        }

        public string DialogHeaderCaption
        {
            get { return _issueViewModel.Id == 0 ? "Add issue" : "Edit issue"; }
        }

        public string DialogSubHeaderCaption
        {
            get { return _issueViewModel.Id == 0 ? "Create a new issue" : "You're editing an existing issue"; }
        }

        public string Short
        {
            get { return _issueViewModel.Short; }
            set { _issueViewModel.Short = value; }
        }

        public string Description
        {
            get { return _issueViewModel.Description; }
            set { _issueViewModel.Description = value; }
        }

        public IssueStatus Status
        {
            get { return _issueViewModel.Status; }
            set { _issueViewModel.Status = value; }
        }

        public void ActivateIssue(IssueViewModel issueViewModel)
        {
            _issueViewModel = issueViewModel;
        }

        public void SaveIssue()
        {
            DetermineOperation();
            _attachedView.Close();
        }

        protected override void OnViewAttached(object view, object context)
        {
            _attachedView = (Window) view;
        }

        private void DetermineOperation()
        {
            if (_issueViewModel.Id == 0)
            {
                _issueBusiness.Create(_issueViewModel.Issue);
                _issueSelection.Issues.Add(_issueViewModel);
            }
            else
            {
                _issueBusiness.Update(_issueViewModel.Issue);
            }
        }
    }
}