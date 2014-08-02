using System;
using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.ViewModels.Projects
{
    [Export(typeof(IProjectEditViewModel))]
    public class ProjectEditViewModel : Screen, IProjectEditViewModel, IDisposable
    {
        private readonly ProjectSelection _projectSelection;
        private Window _attachedView;
        private ProjectViewModel _projectViewModel;

        [ImportingConstructor]
        public ProjectEditViewModel(IProjectBusiness projectBusiness, ProjectSelection projectSelection)
        {
            _projectSelection = projectSelection;
            _projectSelection.ProjectChanged += OnProjectChanged;
        }

        public string ProjectDialogHeaderCaption
        {
            get { return _projectViewModel.Exists ? "Add project" : "Edit project"; }
        }

        public string ProjectDialogSubHeaderCaption
        {
            get { return _projectViewModel.Exists ? "Create a new project" : "You're editing an existing project"; }
        }

        public string ProjectShort
        {
            get { return _projectViewModel.Short; }
            set
            {
                _projectViewModel.Short = value;
                NotifyOfPropertyChange(() => ProjectShort);
            }
        }

        public void Dispose()
        {
            _projectSelection.ProjectChanged -= OnProjectChanged;
        }

        protected override void OnViewAttached(object view, object context)
        {
            _attachedView = (Window) view;
        }

        private void OnProjectChanged(object sender, ProjectViewModel projectViewModel)
        {
            _projectViewModel = projectViewModel;
            DisplayName = _projectViewModel.Exists ? "Add project" : "Edit project";

            NotifyOfPropertyChange(() => ProjectDialogHeaderCaption);
            NotifyOfPropertyChange(() => ProjectDialogSubHeaderCaption);
        }

        public void SaveProject()
        {
            _attachedView.DialogResult = true;
        }
    }
}