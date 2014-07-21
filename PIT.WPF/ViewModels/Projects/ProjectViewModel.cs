using Caliburn.Micro;
using PIT.Business.Entities;

namespace PIT.WPF.ViewModels.Projects
{
    public class ProjectViewModel : PropertyChangedBase, IProjectViewModel
    {
        public Project Project { get; set; }

        public int Id
        {
            get { return Project.Id; }
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

        public void Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}
