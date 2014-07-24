using System.ComponentModel.Composition;
using PIT.Business.Service;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Commands.Project
{
    [Export]
    public class DeleteProjectCommand : Command
    {
        private readonly IProjectSelection _projectSelection;
        private readonly IProjectBusiness _projectBusiness;

        [ImportingConstructor]
        public DeleteProjectCommand(IProjectSelection projectSelection, IProjectBusiness projectBusiness)
        {
            _projectSelection = projectSelection;
            _projectBusiness = projectBusiness;
        }

        public override void Execute(object parameter)
        {
            var selectedProject = _projectSelection.SelectedProject;
            _projectBusiness.Delete(selectedProject.Project);
            _projectSelection.Projects.Remove(selectedProject);
        }
    }
}