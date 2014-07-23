using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.Commands.Project
{
    [Export]
    public class AddProjectCommand : Command
    {
        private readonly IWindowManager _windowManager;
        private readonly IProjectViewModelFactory _projectViewModelFactory;
        private readonly IProjectEditViewModel _projectEditViewModel;

        [ImportingConstructor]
        public AddProjectCommand(IWindowManager windowManager, IProjectEditViewModel projectEditViewModel, IProjectViewModelFactory projectViewModelFactory) 
        {
            _windowManager = windowManager;
            _projectViewModelFactory = projectViewModelFactory;
            _projectEditViewModel = projectEditViewModel;
        }

        public override void Execute(object parameter)
        {
            var projectViewModel = _projectViewModelFactory.CreateProjectViewModel();
            _projectEditViewModel.ActivateProject(projectViewModel);
            _windowManager.ShowDialog(_projectEditViewModel);
        }
    }
}