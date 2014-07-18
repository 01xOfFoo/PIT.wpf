using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;

namespace PIT.WPF.ViewModels.Projects
{
    [Export]
    public class ProjectsModel
    {
        public event EventHandler ProjectChanged;

        private ProjectViewModel _selectedProjectViewModel;
        public ProjectViewModel SelectedProject
        {
            get { return _selectedProjectViewModel; }
            set
            {
                _selectedProjectViewModel = value;
                NotifyOfProjectChanged(_selectedProjectViewModel);
            }
        }
        public ObservableCollection<ProjectViewModel> Projects;

        public ProjectsModel()
        {
            Projects = new ObservableCollection<ProjectViewModel>();
        }

        public void NotifyOfProjectChanged(ProjectViewModel projectViewModel)
        {
            if ((ProjectChanged != null) && (projectViewModel != null))
            {
                ProjectChanged(projectViewModel, EventArgs.Empty);
            }
        }
    }
}
