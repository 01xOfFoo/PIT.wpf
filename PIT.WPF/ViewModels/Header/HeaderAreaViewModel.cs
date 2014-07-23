using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Header.Contracts;

namespace PIT.WPF.ViewModels.Header
{
    [Export(typeof(IHeaderAreaViewModel))]
    public class HeaderAreaViewModel : PropertyChangedBase, IHeaderAreaViewModel, IDisposable
    {
        private readonly ProjectsModel _projectsModel;

        [ImportingConstructor]
        public HeaderAreaViewModel(ProjectsModel projectsModel)
        {
            this._projectsModel = projectsModel;
            this._projectsModel.ProjectChanged += new EventHandler(OnProjectChanged);
        }

        private void OnProjectChanged(object sender, EventArgs e)
        {
            NotifyOfPropertyChange(() => SelectedProjectName);
        }

        public string SelectedProjectName 
        {
            get 
            {
                return _projectsModel.SelectedProject == null ? "" : _projectsModel.SelectedProject.Short;
            }
        }

        public void Dispose()
        {
            _projectsModel.ProjectChanged -= OnProjectChanged;
        }
    }
}
