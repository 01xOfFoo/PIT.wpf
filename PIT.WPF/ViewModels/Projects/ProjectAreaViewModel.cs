using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using PIT.Business.Service.Contracts;
using PIT.WPF.Helpers.Contracts;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.ViewModels.Projects
{
    [Export(typeof(IProjectAreaViewModel))]
    public class ProjectAreaViewModel : PropertyChangedBase, IProjectAreaViewModel
    {
        private readonly IProjectSelector _projectSelector;
        private readonly IProjectBusiness _projectBusiness;

        private ObservableCollection<ProjectViewModel> _projects;
        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                return _projects;
            }
            set 
            {
                _projects = value;
                NotifyOfPropertyChange(() => Projects);
            }
        }

        private ProjectViewModel _selectedProject;
        public ProjectViewModel SelectedProject
        {
            get
            {
                return _selectedProject;
            }
            set
            {
                _selectedProject = value;
                _projectSelector.NotifyOfProjectChanged(_selectedProject);
            }
        }

        [ImportingConstructor]
        public ProjectAreaViewModel(IProjectBusiness projectBusiness, IProjectSelector projectSelector)
        {
            _projectBusiness = projectBusiness;
            _projectSelector = projectSelector;

            LoadProjects();
            SelectedProject = _projects.FirstOrDefault();
        }

        private void LoadProjects()
        {
            var prjs = (from project in _projectBusiness.GetAll()
                        select new ProjectViewModel(project)).ToList();

            Projects = new ObservableCollection<ProjectViewModel>(prjs);
        }
    }
}
