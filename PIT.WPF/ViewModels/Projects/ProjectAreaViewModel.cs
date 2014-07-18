using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using Microsoft.Practices.ServiceLocation;
using PIT.Business.Service.Contracts;
using PIT.WPF.Commands.Project;
using PIT.WPF.ViewModels.Projects.Contracts;
using PIT.WPF.Views.Projects;

namespace PIT.WPF.ViewModels.Projects
{
    [Export(typeof(IProjectAreaViewModel))]
    public class ProjectAreaViewModel : Screen, IProjectAreaViewModel
    {
        private readonly IWindowManager _windowManager;
        private readonly ProjectsModel _projectsModel;
        private readonly IProjectBusiness _projectBusiness;
        private readonly ICommand _addProjectCommand;

        private ProjectViewModel _selectedProject;

        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                return _projectsModel.Projects;
            }
        }

        public ProjectViewModel SelectedProject
        {
            get { return _projectsModel.SelectedProject; }
            set { _projectsModel.SelectedProject = value; }
        }

        [ImportingConstructor]
        public ProjectAreaViewModel(IWindowManager windowManager, IProjectBusiness projectBusiness, ProjectsModel projectsModel, AddProjectCommand addProjectCommand)
        {
            _windowManager = windowManager;
            _projectBusiness = projectBusiness;
            _projectsModel = projectsModel;
            _projectsModel.Projects.CollectionChanged += ProjectsOnCollectionChanged;
            _addProjectCommand = addProjectCommand;

            LoadProjects();
        }

        private void ProjectsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            NotifyOfPropertyChange(() => Projects);
        }

        public ICommand AddProject
        {
            get { return _addProjectCommand; }
        }

        protected override void OnViewAttached(object view, object context)
        {
            BindContextMenu((ProjectAreaView) view);
        }

        private static void BindContextMenu(ProjectAreaView projectView)
        {
            var instance = ServiceLocator.Current.GetInstance<IProjectCommands>();
            ViewModelBinder.Bind(instance, (DependencyObject) projectView.FindResource("ProjectContextMenu"), null);
        }

        private void LoadProjects()
        {
            var prjs = (from project in _projectBusiness.GetAll()
                        select new ProjectViewModel() { Project = project }).ToList();

            _projectsModel.Projects = new ObservableCollection<ProjectViewModel>(prjs);
        }
    }
}
