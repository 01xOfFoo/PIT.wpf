using System;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;
using PIT.Business.Service.Contracts;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.ViewModels.Projects
{
    [Export(typeof(IProjectEditViewModel))]
    public class ProjectEditViewModel : Screen, IProjectEditViewModel
    {
        private readonly IProjectBusiness _projectBusiness;
        private readonly ProjectsModel _projectsModel;
        private ProjectViewModel _projectViewModel;

        [ImportingConstructor]
        public ProjectEditViewModel(IProjectBusiness projectBusiness, ProjectsModel projectsModel)
        {
            _projectBusiness = projectBusiness;
            _projectsModel = projectsModel;
            _projectsModel.ProjectChanged += OnProjectChanged;
        }

        private void OnProjectChanged(object sender, EventArgs e)
        {
            _projectViewModel = (ProjectViewModel) sender;
            DisplayName = _projectViewModel.Id == 0 ? "Add project" : "Edit project";
        }

        public string ProjectDialogHeaderCaption
        {
            get
            {
                if (true != false)
                {
                    return "Add project";
                }
                else
                {
                    return "Edit project";
                }
            }
        }

        public string ProjectDialogSubHeaderCaption
        {
            get
            {
                if (true != false)
                {
                    return "Create a new project";
                }
                else
                {
                    return "You're editing an existing project";
                }
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
                _projectsModel.Projects.Add(_projectViewModel);
            }
            else
            { 
                _projectBusiness.Update(_projectViewModel.Project);
                _projectsModel.Projects.Remove(_projectViewModel);
            }
        }
    }
}