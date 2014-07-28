using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.Commands.Project
{
    [Export]
    public class AddProjectCommand : Command
    {
        private readonly IProjectBusiness _projectBusiness;
        private readonly IProjectEditViewModel _projectEditViewModel;
        private readonly ProjectSelection _projectSelection;
        private readonly IProjectViewModelFactory _projectViewModelFactory;
        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public AddProjectCommand(IWindowManager windowManager, IProjectBusiness projectBusiness,
            ProjectSelection projectSelection, IProjectEditViewModel projectEditViewModel,
            IProjectViewModelFactory projectViewModelFactory)
        {
            _windowManager = windowManager;
            _projectBusiness = projectBusiness;
            _projectViewModelFactory = projectViewModelFactory;
            _projectEditViewModel = projectEditViewModel;
            _projectSelection = projectSelection;
        }

        public override void Execute(object parameter)
        {
            ProjectViewModel oldProject = _projectSelection.SelectedProject;

            _projectSelection.SelectedProject = _projectViewModelFactory.CreateProjectViewModel();
            bool? result = _windowManager.ShowDialog(_projectEditViewModel);
            if (result != null && result == true)
            {
                _projectBusiness.Create(_projectSelection.SelectedProject.Project);
                _projectSelection.Projects.Add(_projectSelection.SelectedProject);
            }
            else
            {
                _projectSelection.SelectedProject = oldProject;
            }
        }
    }
}