using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;
using PIT.Business.Service.Contracts;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.ViewModels.Projects
{
    [Export(typeof(IProjectEditViewModel))]
    public class ProjectEditViewModel : Screen, IProjectEditViewModel
    {
        private readonly IProjectBusiness _projectBusiness;
        private readonly ProjectSelection _projectSelection;
        private  ProjectViewModel _projectViewModel;

        [ImportingConstructor]
        public ProjectEditViewModel(IProjectBusiness projectBusiness, ProjectSelection projectSelection)
        {
            _projectBusiness = projectBusiness;
            _projectSelection = projectSelection;
        }

        public void ActivateProject(ProjectViewModel projectViewModel)
        {
            _projectViewModel = projectViewModel;

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

            var window = Application.Current.Windows[Application.Current.Windows.Count - 1];
            if (window != null)
                window.Close();
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