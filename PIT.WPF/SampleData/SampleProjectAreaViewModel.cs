using System.Collections.ObjectModel;
using System.Linq;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.SampleData
{
    class SampleProjectAreaViewModel : IProjectAreaViewModel
    {
        public ObservableCollection<ProjectViewModel> Projects { get; set; }
        public ProjectViewModel SelectedProject { get; set; }

        public SampleProjectAreaViewModel()
        {
            Projects = new ObservableCollection<ProjectViewModel>
            {
                new ProjectViewModel
                ( 
                    new Project
                    {
                        Id = 0,
                        Short = "PROJEKT 1"
                    }
                ),
                new ProjectViewModel
                (
                    new Project
                    {
                        Id = 1,
                        Short = "PROJEKT 2"
                    }
                )
            };

            SelectedProject = Projects.First();
        }
    }
}
