using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IIssueEditViewModel))]
    public class IssueEditViewModel : PropertyChangedBase, IIssueEditViewModel
    {
        private IssueStatus _status;

        public IssueEditViewModel()
        {
            _status = IssueStatus.Assigned;
        }

        public IssueStatus Status
        {
            get { return _status; } 
            set { _status = value; }
        }
    }
}
