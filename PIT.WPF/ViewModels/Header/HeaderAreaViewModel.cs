using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.Helpers.Contracts;
using PIT.WPF.ViewModels.Header.Contracts;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.ViewModels.Header
{
    [Export(typeof(IHeaderAreaViewModel))]
    public class HeaderAreaViewModel : PropertyChangedBase, IHeaderAreaViewModel, IDisposable
    {
        private readonly IProjectSelector _projectSelector;
        private ProjectViewModel _projectViewModel;

        [ImportingConstructor]
        public HeaderAreaViewModel(IProjectSelector projectSelector)
        {
            this._projectSelector = projectSelector;
            this._projectSelector.ProjectChanged += new EventHandler(OnProjectChanged);
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
                    return _projectViewModel.Name;
                else
                    return "";
            }
        }

        public void Dispose()
        {
            _projectSelector.ProjectChanged -= OnProjectChanged;
        }
    }
}
