using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Commands.Project
{
    public abstract class ProjectCommand : Command
    {
        public ProjectsModel ProjectsModel { get; set; }

        protected readonly IProjectBusiness ProjectBusiness;

        public ProjectCommand(ProjectsModel projectsModel, IProjectBusiness projectBusiness)
        {
            ProjectsModel = projectsModel;
            ProjectBusiness = projectBusiness;
        }
    }
}