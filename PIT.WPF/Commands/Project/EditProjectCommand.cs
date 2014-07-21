using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.Commands.Project
{
    [Export]
    public class EditProjectCommand : ProjectCommand
    {
        private readonly IWindowManager _windowManager;
        private readonly IProjectEditViewModel _projectEditViewModel;

        [ImportingConstructor]
        public EditProjectCommand(ProjectsModel projectsModel, IProjectBusiness projectBusiness, IWindowManager windowManager, IProjectEditViewModel projectEditViewModel)
            : base(projectsModel, projectBusiness)
        {
            _windowManager = windowManager;
            _projectEditViewModel = projectEditViewModel;
        }

        public override void Execute(object parameter)
        {
            _windowManager.ShowWindow(_projectEditViewModel);
        }
    }
}