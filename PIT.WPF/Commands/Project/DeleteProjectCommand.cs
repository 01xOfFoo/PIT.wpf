using System.ComponentModel.Composition;
using System.Reactive.Linq;
using PIT.Business.Entities.Events.Projects;
using PIT.Business.Service.Contracts;
using PIT.Core;
using PIT.WPF.Models.Projects;
using PIT.WPF.Models.Projects.Contracts;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Commands.Project
{
    [Export]
    public class DeleteProjectCommand : Command
    {
        private readonly IProjectBusiness _projectBusiness;
        private readonly ProjectSelection _projectSelection;

        [ImportingConstructor]
        public DeleteProjectCommand(ProjectSelection projectSelection, IProjectBusiness projectBusiness)
        {
            _projectSelection = projectSelection;
            _projectBusiness = projectBusiness;
        }

        public override void Execute(object parameter)
        {
            ProjectViewModel selectedProject = _projectSelection.SelectedProject;
            _projectBusiness.Delete(selectedProject.Project);
            _projectSelection.Projects.Remove(selectedProject);
            Events.Current.Publish(new ProjectDeleted(selectedProject.Project));
        }
    }
}