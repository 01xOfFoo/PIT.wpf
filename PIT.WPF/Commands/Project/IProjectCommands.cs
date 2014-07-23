using System.Windows.Input;

namespace PIT.WPF.Commands.Project
{
    public interface IProjectCommands
    {
        EditProjectCommand EditProject { get; set; }
        DeleteProjectCommand DeleteProject { get; set; }
    }
}