using System.ComponentModel.Composition;
using PIT.Business.Service.Contracts;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Commands.Project
{
    [Export]
    public class DeleteProjectCommand : ProjectCommand
    {
        [ImportingConstructor]
        public DeleteProjectCommand(ProjectsModel projectsModel, IProjectBusiness projectBusiness)
            : base(projectsModel, projectBusiness)
        {
        }

        public override void Execute(object parameter)
        {
            ProjectBusiness.Delete(ProjectsModel.SelectedProject.Project);
            ProjectsModel.Projects.Remove(ProjectsModel.SelectedProject);
        }
    }
}