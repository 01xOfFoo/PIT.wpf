namespace PIT.Business.Entities.Events.Projects
{
    public abstract class ProjectEvent
    {
        public Project Project { get; private set; }

        protected ProjectEvent(Project project)
        {
            Project = project;
        }
    }
}