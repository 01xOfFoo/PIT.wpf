using System;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Models.Projects
{
    [Export(typeof(IProjectSelector))]
    public class ProjectSelector : IProjectSelector, IDisposable
    {
        private readonly ProjectSelection _projectSelection;

        [ImportingConstructor]
        public ProjectSelector(ProjectSelection projectSelection)
        {
            _projectSelection = projectSelection;
            _projectSelection.ProjectsUpdates += OnProjectsUpdates;
        }

        public void Dispose()
        {
            _projectSelection.ProjectsUpdates -= OnProjectsUpdates;
        }

        private void OnProjectsUpdates(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            if (notifyCollectionChangedEventArgs.Action == NotifyCollectionChangedAction.Add)
                _projectSelection.SelectedProject = (ProjectViewModel) notifyCollectionChangedEventArgs.NewItems[0];
            else
                _projectSelection.SelectedProject = _projectSelection.Projects.FirstOrDefault();
        }
    }
}