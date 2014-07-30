using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Models.Projects
{
    [Export]
    public class ProjectSelection
    {
        private ProjectViewModel _selectedProjectViewModel;

        public ProjectSelection()
        {
            Projects = new ObservableCollection<ProjectViewModel>();
        }

        public ObservableCollection<ProjectViewModel> Projects { get; set; }

        public ProjectViewModel SelectedProject
        {
            get { return _selectedProjectViewModel; }
            set
            {
                _selectedProjectViewModel = value;
                NotifyOfProjectChanged(_selectedProjectViewModel);
            }
        }

        public event EventHandler<ProjectViewModel> ProjectChanged;


        private void NotifyOfProjectChanged(ProjectViewModel projectViewModel)
        {
            if ((ProjectChanged != null) && (projectViewModel != null))
            {
                ProjectChanged(this, projectViewModel);
            }
        }

        // Testing purpose only
        public bool HasProjectChangedSubscriber()
        {
            return (ProjectChanged != null);
        }
    }
}