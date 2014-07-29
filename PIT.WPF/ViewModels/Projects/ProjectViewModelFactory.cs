using System.ComponentModel.Composition;
using PIT.Business.Contracts;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Contracts;

namespace PIT.WPF.ViewModels.Projects
{
    [Export(typeof(IViewModelFactory<ProjectViewModel, Project>))]
    public class ProjectViewModelFactory : IViewModelFactory<ProjectViewModel, Project>
    {
        private readonly IProjectFactory _projectFactory;

        [ImportingConstructor]
        public ProjectViewModelFactory(IProjectFactory projectFactory)
        {
            _projectFactory = projectFactory;
        }

        public ProjectViewModel CreateViewModel(Project entity)
        {
            Project project = entity ?? _projectFactory.CreateProject();
            return new ProjectViewModel {Project = project};
        }
    }
}