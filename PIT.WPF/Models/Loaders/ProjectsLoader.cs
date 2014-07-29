using System.ComponentModel.Composition;
using PIT.Business.Entities;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Loaders.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Contracts;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Models.Loaders
{
    [Export(typeof(ILoader<ProjectViewModel, Project>))]
    public class ProjectsLoader : Loader<ProjectViewModel, Project>
    {
        [ImportingConstructor]
        public ProjectsLoader(IProjectBusiness business, IViewModelFactory<ProjectViewModel, Project> factory,
            ProjectSelection projectSelection)
            : base(business, factory)
        {
            Collection = projectSelection.Projects;
        }
    }
}