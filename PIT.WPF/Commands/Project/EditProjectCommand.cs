using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.Commands.Project
{
    [Export]
    public class EditProjectCommand : Command
    {
        private readonly ProjectSelection _projectModel;
        private readonly IWindowManager _windowManager;
        private readonly IProjectEditViewModel _projectEditViewModel;

        [ImportingConstructor]
        public EditProjectCommand(ProjectSelection projectSelection, IWindowManager windowManager, IProjectEditViewModel projectEditViewModel)
        {
            _projectModel = projectSelection;
            _windowManager = windowManager;
            _projectEditViewModel = projectEditViewModel;
        }

        public override void Execute(object parameter)
        {
            var history = new EntityHistory<ProjectViewModel>(_projectSelection.SelectedProject);

            bool? result = _windowManager.ShowDialog(_projectEditViewModel);
            if (result != null && result == false)
            {
                history.Restore();
            }
        }
    }
}