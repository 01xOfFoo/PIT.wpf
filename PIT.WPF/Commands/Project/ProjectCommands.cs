using System.ComponentModel.Composition;

namespace PIT.WPF.Commands.Project
{
    [Export(typeof(IProjectCommands))]
    public class ProjectCommands : IProjectCommands
    {
        [Import]
        public EditProjectCommand EditProject { get; set; }

        [Import]
        public DeleteProjectCommand DeleteProject { get; set; }
    }
}