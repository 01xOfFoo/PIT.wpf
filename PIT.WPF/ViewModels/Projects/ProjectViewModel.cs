using Caliburn.Micro;
using PIT.Business.Entities;

namespace PIT.WPF.ViewModels.Projects
{
    public class ProjectViewModel : PropertyChangedBase
    {
        public Project Project { get; set; }

        public int Id
        {
            get { return Project.Id; }
        }

        public bool Exists
        {
            get { return Id != 0; }
        }

        public string Short
        {
            get
            {
                return Project.Short;
            }
            set
            {
                Project.Short = value;
                NotifyOfPropertyChange(() => Short);
            }
        }
    }
}
