using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Specialized;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Models.Projects
{
    [Export(typeof(IProjectSelector))]
    public class ProjectSelector : IProjectSelector, IDisposable
    {
        private readonly ProjectsModel _projectsModel;

        [ImportingConstructor]
        public ProjectSelector(ProjectsModel projectsModel)
        {
            _projectsModel = projectsModel;
            _projectsModel.ProjectsUpdates += OnProjectsUpdates;
        }

        private void OnProjectsUpdates(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            if (notifyCollectionChangedEventArgs.Action == NotifyCollectionChangedAction.Remove)
                _projectsModel.SelectedProject = _projectsModel.Projects.FirstOrDefault();
            else
                _projectsModel.SelectedProject = (ProjectViewModel) notifyCollectionChangedEventArgs.NewItems[0];

        }

        public void Dispose()
        {
            _projectsModel.ProjectsUpdates -= OnProjectsUpdates;
        }
    }
}