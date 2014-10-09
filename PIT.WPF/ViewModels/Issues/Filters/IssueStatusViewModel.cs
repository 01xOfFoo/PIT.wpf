using PIT.Business.Entities;
using PIT.WPF.Helper;

namespace PIT.WPF.ViewModels.Issues.Filters
{
    public class IssueStatusViewModel
    {
        private readonly IssueStatus _issueStatus;

        public IssueStatusViewModel(IssueStatus issueStatus)
        {
            _issueStatus = issueStatus;
        }

        public string Name
        {
            get { return EnumExtension.GetEnumDescription(_issueStatus); }
        }

        public IssueStatus Status
        {
            get { return _issueStatus; }
        }
    }
}