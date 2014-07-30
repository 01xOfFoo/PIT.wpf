namespace PIT.Business.Entities.Events.Projects
{
    public class ProjectDeleted : ProjectEvent
    {
        public ProjectDeleted(Project project) : base(project)
        {
        }
    }
}