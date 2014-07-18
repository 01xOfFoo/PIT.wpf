using PIT.Business.Entities;

namespace PIT.WPF.ViewModels.Projects
{
    public interface IProjectViewModelFactory
    {
        ProjectViewModel CreateProjectViewModel(Project project);
    }
}