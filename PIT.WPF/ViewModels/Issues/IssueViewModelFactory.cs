using System.ComponentModel.Composition;
using PIT.Business.Entities;
using PIT.Business.Factories.Contracts;
using PIT.WPF.ViewModels.Contracts;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IViewModelFactory<IssueViewModel, Issue>))]
    public class IssueViewModelFactory : IViewModelFactory<IssueViewModel, Issue>
    {
        private readonly IIssueFactory _issueFactory;

        [ImportingConstructor]
        public IssueViewModelFactory(IIssueFactory issueFactory)
        {
            _issueFactory = issueFactory;
        }

        public IssueViewModel CreateViewModel(Issue entity)
        {
            Issue issue = entity ?? _issueFactory.CreateIssue();
            return new IssueViewModel {Issue = issue};
        }
    }
}