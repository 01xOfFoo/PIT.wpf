using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.Commands.Issue;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IIssueHeaderAreaViewModel))]
    public class IssueHeaderAreaViewModel : Screen, IIssueHeaderAreaViewModel
    {
        private readonly AddIssueCommand _addIssueCommand;

        [ImportingConstructor]
        public IssueHeaderAreaViewModel(AddIssueCommand addIssueCommand)
        {
            _addIssueCommand = addIssueCommand;
        }

        [Import]
        public IIssueStatusFilterViewModel IssueStatusFilter { get; set; }

        public AddIssueCommand AddIssueCommand
        {
            get { return _addIssueCommand; }
        }
    }
}