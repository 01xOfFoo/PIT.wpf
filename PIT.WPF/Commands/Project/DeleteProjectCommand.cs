using System.ComponentModel.Composition;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Projects.Contracts;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Commands.Project
{
    [Export]
    public class DeleteProjectCommand : Command
    {
        private readonly IProjectBusiness _projectBusiness;
        private readonly IProjectSelection _projectSelection;

        [ImportingConstructor]
        public DeleteProjectCommand(IProjectSelection projectSelection, IProjectBusiness projectBusiness)
        {
            _projectSelection = projectSelection;
            _projectBusiness = projectBusiness;
        }

        public override void Execute(object parameter)
        {
            ProjectViewModel selectedProject = _projectSelection.SelectedProject;
            _projectBusiness.Delete(selectedProject.Project);
            _projectSelection.Projects.Remove(selectedProject);
        }
    }
}