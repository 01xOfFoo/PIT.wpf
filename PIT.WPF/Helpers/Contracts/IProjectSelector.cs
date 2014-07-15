using System;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Helpers.Contracts
{
    public interface IProjectSelector
    {
        void NotifyOfProjectChanged(ProjectViewModel projectViewModel);
        event EventHandler ProjectChanged;
    }
}
