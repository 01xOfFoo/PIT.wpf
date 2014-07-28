using System.ComponentModel.Composition;
using System.Windows.Documents;
using Caliburn.Micro;
using PIT.WPF.Models.Projects;
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
        private readonly ProjectSelection _projectSelection;

        [ImportingConstructor]
        public AddProjectCommand(IWindowManager windowManager, ProjectSelection projectSelection, IProjectEditViewModel projectEditViewModel, IProjectViewModelFactory projectViewModelFactory) 
        {
            _windowManager = windowManager;
            _projectViewModelFactory = projectViewModelFactory;
            _projectEditViewModel = projectEditViewModel;
            _projectSelection = projectSelection;
        }

        public override void Execute(object parameter)
        {
            var oldProject = _projectSelection.SelectedProject;

            _projectSelection.SelectedProject = _projectViewModelFactory.CreateProjectViewModel();
            var result = _windowManager.ShowDialog(_projectEditViewModel);
            if (result != null && !result.Value)
            {
                _projectSelection.SelectedProject = oldProject;
            }
        }
    }
}