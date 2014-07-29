using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using Microsoft.Practices.ServiceLocation;
using PIT.Business.Entities;
using PIT.WPF.Commands.Project;
using PIT.WPF.Models.Loaders.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;
using PIT.WPF.Views.Projects;

namespace PIT.WPF.ViewModels.Projects
{
    [Export(typeof(IProjectAreaViewModel))]
    public class ProjectAreaViewModel : Screen, IProjectAreaViewModel
    {
        private readonly ICommand _addProjectCommand;
        private readonly ILoader<ProjectViewModel, Project> _projectLoader;
        private readonly ProjectSelection _projectSelection;
        private readonly IProjectSelector _projectSelector;
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public ProjectAreaViewModel(IWindowManager windowManager, ILoader<ProjectViewModel, Project> projectLoader,
            ProjectSelection projectSelection, IProjectSelector projectSelector, AddProjectCommand addProjectCommand)
        {
            _windowManager = windowManager;

            _projectSelection = projectSelection;
            _projectSelection.ProjectChanged += OnProjectChanged;
            _projectSelection.Projects.CollectionChanged += OnProjectsUpdates;

            _projectLoader = projectLoader;
            _projectLoader.Load();

            _addProjectCommand = addProjectCommand;
            _projectSelector = projectSelector;
        }

        public ICommand AddProject
        {
            get { return _addProjectCommand; }
        }

        public ObservableCollection<ProjectViewModel> Projects
        {
            get { return _projectSelection.Projects; }
        }

        public ProjectViewModel SelectedProject
        {
            get { return _projectSelection.SelectedProject; }
            set { _projectSelection.SelectedProject = value; }
        }

        private void OnProjectChanged(object sender, EventArgs eventArgs)
        {
            NotifyOfPropertyChange(() => SelectedProject);
        }

        private void OnProjectsUpdates(object sender, EventArgs eventArgs)
        {
            NotifyOfPropertyChange(() => Projects);
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
    }
}