using System;
using System.ComponentModel.Composition;
using PIT.WPF.Helpers.Contracts;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.Helpers
{
    [Export(typeof(IProjectSelector))]
    public class ProjectSelector : IProjectSelector
    {
        public event EventHandler ProjectChanged;

        public void NotifyOfProjectChanged(ProjectViewModel projectViewModel)
        {
            if ((ProjectChanged != null) && (projectViewModel != null))
            {
                ProjectChanged(projectViewModel, EventArgs.Empty);
            }
        }
    }
}
