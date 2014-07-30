using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using PIT.Business.Entities;
using PIT.Business.Entities.Events.Projects;
using PIT.Business.Service.Contracts;
using PIT.Core;
using PIT.WPF.Models.Loaders.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Contracts;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Models.Loaders
{
    [Export(typeof(ILoader<ProjectViewModel, Project>))]
    public class ProjectsLoader : Loader<ProjectViewModel, Project>
    {
        private readonly ProjectSelection _projectSelection;

        [ImportingConstructor]
        public ProjectsLoader(IProjectBusiness issueBusiness, IViewModelFactory<ProjectViewModel, Project> factory,
            ProjectSelection projectSelection)
            : base(issueBusiness, factory)
        {
            _projectSelection = projectSelection;
        }

        protected override void SetCollection(ObservableCollection<ProjectViewModel> collection)
        {
            _projectSelection.Projects = collection;
            Events.Current.Publish(new ProjectsLoaded());
        }
    }
}