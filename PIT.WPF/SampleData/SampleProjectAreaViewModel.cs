using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.SampleData
{
    [ExcludeFromCodeCoverage]
    class SampleProjectAreaViewModel : IProjectAreaViewModel
    {
        public ObservableCollection<ProjectViewModel> Projects { get; set; }
        public ProjectViewModel SelectedProject { get; set; }

        public SampleProjectAreaViewModel()
        {
            Projects = new ObservableCollection<ProjectViewModel>
            {
                new ProjectViewModel
                {
                    Project = new Project
                    {
                        Id = 0,
                        Short = "PROJECT 1"
                    }
                },
                new ProjectViewModel()
                {
                    Project = new Project
                    {
                        Id = 1,
                        Short = "PROJECT 2"
                    }
                }
            };

            SelectedProject = Projects.First();
        }
    }
}
