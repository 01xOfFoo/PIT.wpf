using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using PIT.Business.Entities.Events.Projects;
using PIT.Core;
using PIT.WPF.Models.Projects.Contracts;

namespace PIT.WPF.Models.Projects
{
    [Export(typeof(IProjectSelector))]
    public class ProjectSelector : IProjectSelector, IDisposable
    {
        private readonly Disposer _disposer = new Disposer();
        private readonly ProjectSelection _projectSelection;

        [ImportingConstructor]
        public ProjectSelector(ProjectSelection projectSelection)
        {
            _projectSelection = projectSelection;
            _disposer.Add(Events.Current.OfType<ProjectDeleted>().Subscribe(e => OnProjectDeleted(e)));
            _disposer.Add(Events.Current.OfType<ProjectsLoaded>().Subscribe(e => OnProjectsLoaded(e)));
        }

        public void Dispose()
        {
            _disposer.Dispose();
        }

        private void OnProjectsLoaded(ProjectsLoaded projectsLoaded)
        {
            SelectFirstProject();
        }

        private void SelectFirstProject()
        {
            _projectSelection.SelectedProject = _projectSelection.Projects.FirstOrDefault();
        }

        private void OnProjectDeleted(ProjectDeleted e)
        {
            SelectFirstProject();
        }
    }
}