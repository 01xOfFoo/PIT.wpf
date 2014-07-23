using System.ComponentModel.Composition;
using PIT.Business.Contracts;

namespace PIT.WPF.ViewModels.Projects
{
    [Export(typeof(IProjectViewModelFactory))]
    public class ProjectViewModelFactory : IProjectViewModelFactory
    {
        private readonly IProjectFactory _projectFactory;

        [ImportingConstructor]
        public ProjectViewModelFactory(IProjectFactory projectFactory)
        {
            _projectFactory = projectFactory;
        }

        public ProjectViewModel CreateProjectViewModel()
        {
            var project = _projectFactory.CreateProject();
            return new ProjectViewModel()
            {
                Project = project
            };
        }
    }
}