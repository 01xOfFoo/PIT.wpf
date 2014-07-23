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
        private readonly IProjectsModel _projectsModel;
        private readonly IProjectBusiness _projectBusiness;

        [ImportingConstructor]
        public DeleteProjectCommand(IProjectsModel projectsModel, IProjectBusiness projectBusiness)
        {
            _projectsModel = projectsModel;
            _projectBusiness = projectBusiness;
        }

        public override void Execute(object parameter)
        {
            var selectedProject = _projectsModel.SelectedProject;
            _projectBusiness.Delete(selectedProject.Project);
            _projectsModel.Projects.Remove(selectedProject);
        }
    }
}