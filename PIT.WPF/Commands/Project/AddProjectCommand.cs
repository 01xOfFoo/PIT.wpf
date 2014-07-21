using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.Commands.Project
{
    [Export]
    public class AddProjectCommand : ProjectCommand
    {
        private readonly IWindowManager _windowManager;
        private readonly IProjectViewModelFactory _projectViewModelFactory;
        private readonly IProjectEditViewModel _projectEditViewModel;

        [ImportingConstructor]
        public AddProjectCommand(ProjectsModel projectsModel, IProjectBusiness projectBusiness, IWindowManager windowManager, IProjectEditViewModel projectEditViewModel, IProjectViewModelFactory projectViewModelFactory) 
            : base(projectsModel, projectBusiness)
        {
            _windowManager = windowManager;
            _projectViewModelFactory = projectViewModelFactory;
            _projectEditViewModel = projectEditViewModel;
        }

        public override void Execute(object parameter)
        {
            var project = new Business.Entities.Project();
            var projectViewModel = _projectViewModelFactory.CreateProjectViewModel(project);
            ProjectsModel.SelectedProject = projectViewModel;
            _windowManager.ShowDialog(_projectEditViewModel);
        }
    }
}