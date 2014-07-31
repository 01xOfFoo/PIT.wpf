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
        private readonly IssueStatusListViewModel _status;

        [ImportingConstructor]
        public IssueHeaderAreaViewModel(AddIssueCommand addIssueCommand)
        {
            _addIssueCommand = addIssueCommand;

            List<IssueStatusViewModel> stati = (from IssueStatus e in Enum.GetValues(typeof(IssueStatus))
                select new IssueStatusViewModel(e)).ToList();
            _status = new IssueStatusListViewModel();
            foreach (IssueStatusViewModel s in stati)
            {
                _status.Add(s);
            }
            NotifyOfPropertyChange(() => Status);
        }

        public IssueStatusListViewModel Status
        {
            get { return _status; }
            private set { throw new NotImplementedException(); }
        }

        public AddIssueCommand AddIssueCommand
        {
            get { return _addIssueCommand; }
        }
    }
}