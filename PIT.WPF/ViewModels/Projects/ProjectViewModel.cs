using Caliburn.Micro;
using PIT.Business.Entities;

namespace PIT.WPF.ViewModels.Projects
{
    public class ProjectViewModel : PropertyChangedBase
    {
        private readonly Project _project;

        public ProjectViewModel(Project project)
        {
            _project = project;
        }

        public int Id
        {
            get { return _project.Id; }
        }

        public string Name
        {
            get
            {
                return _project.Short;
            }
            set
            {
                _project.Short = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
    }
}
