using System.Collections.ObjectModel;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Models.Projects.Contracts
{
    public interface IProjectSelection
    {
        ProjectViewModel SelectedProject { get; set; }
        ObservableCollection<ProjectViewModel> Projects { get; }
    }
}