using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.ViewModels.Header.Contracts;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.ViewModels.Header
{
    [Export(typeof(IHeaderAreaViewModel))]
    public class HeaderAreaViewModel : PropertyChangedBase, IHeaderAreaViewModel, IDisposable
    {
        private readonly ProjectsModel _projectsModel;
        private ProjectViewModel _projectViewModel;

        [ImportingConstructor]
        public HeaderAreaViewModel(ProjectsModel projectsModel)
        {
            this._projectsModel = projectsModel;
            this._projectsModel.ProjectChanged += new EventHandler(OnProjectChanged);
        }

        private void OnProjectChanged(object sender, EventArgs e)
        {
            _projectViewModel = (ProjectViewModel)sender;
            NotifyOfPropertyChange(() => SelectedProjectName);
        }

        public string SelectedProjectName
        {
            get 
            {
                if (_projectViewModel != null)
                    return _projectViewModel.Short;
                else
                    return "";
            }
        }

        public void Dispose()
        {
            _projectsModel.ProjectChanged -= OnProjectChanged;
        }
    }
}
