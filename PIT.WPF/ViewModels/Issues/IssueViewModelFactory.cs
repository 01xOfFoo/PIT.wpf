using System.ComponentModel.Composition;
using PIT.Business.Contracts;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IIssueViewModelFactory))]
    public class IssueViewModelFactory : IIssueViewModelFactory
    {
        private readonly IIssueFactory _issueFactory;

        [ImportingConstructor]
        public IssueViewModelFactory(IIssueFactory issueFactory)
        {
            _issueFactory = issueFactory;
        }

        public IssueViewModel CreateIssueViewModel()
        {
            Issue issue = _issueFactory.CreateIssue();
            return new IssueViewModel(issue);
        }
    }
}