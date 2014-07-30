using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.Business;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.Commands.Project
{
    [Export]
    public class EditProjectCommand : Command
    {
        private readonly IProjectBusiness _projectBusiness;
        private readonly IProjectEditViewModel _projectEditViewModel;
        private readonly ProjectSelection _projectSelection;
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public EditProjectCommand(IWindowManager windowManager, IProjectBusiness projectBusiness,
            ProjectSelection projectSelection, IProjectEditViewModel projectEditViewModel)
        {
            _windowManager = windowManager;
            _projectBusiness = projectBusiness;
            _projectSelection = projectSelection;
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

            if (result != null && result == true)
            {
                _projectBusiness.Update(_projectSelection.SelectedProject.Project);
            }
            else
            {
                history.Restore();
            }
        }
    }
}