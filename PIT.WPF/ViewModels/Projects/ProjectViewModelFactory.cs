using System.ComponentModel.Composition;
using PIT.Business.Entities;

namespace PIT.WPF.ViewModels.Projects
{
    [Export(typeof(IProjectViewModelFactory))]
    public class ProjectViewModelFactory : IProjectViewModelFactory
    {
        public ProjectViewModel CreateProjectViewModel(Project project)
        {
            return new ProjectViewModel()
            {
                Project = project
            };
        }
    }
}