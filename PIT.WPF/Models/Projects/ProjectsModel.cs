using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Models.Projects
{
    [Export]
    public class ProjectsModel
    {
        private ProjectViewModel _selectedProjectViewModel;
        private ObservableCollection<ProjectViewModel> _projects;

        public event EventHandler ProjectChanged;
        public event NotifyCollectionChangedEventHandler ProjectsUpdates;

        public ProjectViewModel SelectedProject
        {
            get { return _selectedProjectViewModel; }
            set
            {
                _selectedProjectViewModel = value;
                NotifyOfProjectChanged(_selectedProjectViewModel);
            }
        }

        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                if (_projects == null)
                    _projects = new ObservableCollection<ProjectViewModel>();

                return _projects;
            }
            set
            {
                _projects = value;
                _projects.CollectionChanged += ProjectsUpdates;
            }
        }

        private void NotifyOfProjectChanged(ProjectViewModel projectViewModel)
        {
            if ((ProjectChanged != null) && (projectViewModel != null))
            {
                ProjectChanged(projectViewModel, EventArgs.Empty);
            }
        }
    }
}
