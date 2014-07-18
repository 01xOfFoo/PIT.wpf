using System.Collections.ObjectModel;

namespace PIT.WPF.ViewModels.Projects.Contracts
{
    public interface IProjectAreaViewModel
    {
        ObservableCollection<ProjectViewModel> Projects { get; }
        ProjectViewModel SelectedProject { get; set; }
    }
}
