using Caliburn.Micro;
using PIT.Business.Entities;

namespace PIT.WPF.ViewModels.Issues
{
    public class IssueViewModel : PropertyChangedBase
    {
        private readonly Issue _issue;

        public IssueViewModel(Issue issue)
        {
            _issue = issue;
        }

        public string IssueNumber
        {
            get
            {
                return string.Format("#{0}", _issue.Id);
            }
        }

        public string Description
        {
            get
            {
                return _issue.Description;
            }
            set
            {
                _issue.Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public IssueStatus Status
        {
            get { return _issue.Status; }
            set
            {
                _issue.Status = value;
                NotifyOfPropertyChange(() => Status);
            }
        }

        public string AssignedToName
        {
            get { return "na"; }
        }
    }
}
