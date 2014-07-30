using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using Caliburn.Micro;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Issues;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IIssueEditViewModel))]
    public class IssueEditViewModel : Screen, IIssueEditViewModel, IDisposable
    {
        private readonly IssueSelection _issueSelection;
        private readonly IUserBusiness _userBusiness;
        private Window _attachedView;
        private IssueViewModel _issueViewModel;

        [ImportingConstructor]
        public IssueEditViewModel(IUserBusiness userBusiness, IssueSelection issueSelection)
        {
            _userBusiness = userBusiness;
            _issueSelection = issueSelection;
            _issueSelection.IssueChanged += OnIssueChanged;

            Users = new ObservableCollection<User>(_userBusiness.GetAll().ToList());
            Users.Insert(0, new User());
        }

        public string DialogHeaderCaption
        {
            get { return _issueViewModel != null && _issueViewModel.Id == 0 ? "Add issue" : "Edit issue"; }
        }

        public string DialogSubHeaderCaption
        {
            get
            {
                return _issueViewModel != null && _issueViewModel.Id == 0
                    ? "Create a new issue"
                    : "You're editing an existing issue";
            }
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

        public User Developer
        {
            get { return _issueViewModel.Developer; }
            set { _issueViewModel.Developer = value; }
        }

        public User Tester
        {
            get { return _issueViewModel.Tester; }
            set { _issueViewModel.Tester = value; }
        }

        public ObservableCollection<User> Users { get; set; }

        public void Dispose()
        {
            _issueSelection.IssueChanged -= OnIssueChanged;
        }

        private void OnIssueChanged(object sender, IssueViewModel issueViewModel)
        {
            _issueViewModel = issueViewModel;

            NotifyOfPropertyChange(() => DialogHeaderCaption);
            NotifyOfPropertyChange(() => DialogSubHeaderCaption);
        }

        public void SaveIssue()
        {
            _attachedView.DialogResult = true;
        }

        protected override void OnViewAttached(object view, object context)
        {
            _attachedView = (Window) view;
        }
    }
}