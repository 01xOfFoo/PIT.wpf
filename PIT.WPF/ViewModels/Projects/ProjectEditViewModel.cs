using System;
using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;
using PIT.WPF.Views.Projects;

namespace PIT.WPF.ViewModels.Projects
{
    [Export(typeof(IProjectEditViewModel))]
    public class ProjectEditViewModel : Screen, IProjectEditViewModel
    {
        private readonly IProjectBusiness _projectBusiness;
        private readonly ProjectSelection _projectSelection;
        private  ProjectViewModel _projectViewModel;
        private Window _attachedView;

        protected override void OnViewAttached(object view, object context)
        {
            _attachedView = (Window)view;
        }

        [ImportingConstructor]
        public ProjectEditViewModel(IProjectBusiness projectBusiness, ProjectSelection projectSelection)
        {
            _projectBusiness = projectBusiness;
            _projectSelection = projectSelection;
            _projectSelection.ProjectChanged += OnProjectChanged;
        }

        private void OnProjectChanged(object sender, EventArgs eventArgs)
        {
            _projectViewModel = (ProjectViewModel) sender;
            DisplayName = _projectViewModel.Exists ? "Add project" : "Edit project";

            NotifyOfPropertyChange(() => ProjectDialogHeaderCaption);
            NotifyOfPropertyChange(() => ProjectDialogSubHeaderCaption);
        }

        public string ProjectDialogHeaderCaption
        {
            get { return _projectViewModel.Exists ? "Add project" : "Edit project"; }
        }

        public string ProjectDialogSubHeaderCaption
        {
            get {
                return _projectViewModel.Exists ? "Create a new project" : "You're editing an existing project";
            }
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

        public void SaveProject()
        {
            DetermineOperation();

            _attachedView.DialogResult = true;
            _attachedView.Close();
        }

        private void DetermineOperation()
        {
            if (_projectViewModel.Id == 0)
            {
                _projectBusiness.Create(_projectViewModel.Project);
                _projectSelection.Projects.Add(_projectViewModel);
            }
            else
            { 
                _projectBusiness.Update(_projectViewModel.Project);
            }
        }
    }
}