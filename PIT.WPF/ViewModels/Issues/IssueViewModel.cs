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

        public string AssignedToName
        {
            get { return "na"; }
        }
    }
}
