using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using PIT.Business.Entities;
using PIT.WPF.Commands.Issue;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IIssueHeaderAreaViewModel))]
    public class IssueHeaderAreaViewModel : Screen, IIssueHeaderAreaViewModel
    {
        private readonly AddIssueCommand _addIssueCommand;
        private readonly IssueStatusListViewModel _statusListViewModel;

        [ImportingConstructor]
        public IssueHeaderAreaViewModel(IssueStatusListViewModel statusListViewModel, AddIssueCommand addIssueCommand)
        {
            _addIssueCommand = addIssueCommand;
            _statusListViewModel = statusListViewModel;

            List<IssueStatusViewModel> stati = (from IssueStatus e in Enum.GetValues(typeof(IssueStatus))
                select new IssueStatusViewModel(e)).ToList();
            foreach (IssueStatusViewModel s in stati)
            {
                _statusListViewModel.Add(s);
            }
            NotifyOfPropertyChange(() => Status);
        }

        public IssueStatusListViewModel Status
        {
            get { return _statusListViewModel; }
            private set { throw new NotImplementedException(); }
        }

        public AddIssueCommand AddIssueCommand
        {
            get { return _addIssueCommand; }
        }
    }
}