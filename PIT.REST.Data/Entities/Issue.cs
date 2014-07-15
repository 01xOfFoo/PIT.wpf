namespace PIT.REST.Data.Entities
{
    public class Issue : Entity
    {
        public Issue()
        {
            Project = new Project();
            Status = IssueStatus.Open;
        }

        public string Description { get; set; }
        public IssueStatus Status { get; set; }

        public Project Project { get; set; }
    }
}