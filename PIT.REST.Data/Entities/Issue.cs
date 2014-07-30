namespace PIT.REST.Data.Entities
{
    public class Issue : Entity
    {
        public int ProjectId { get; set; }
        public int? DeveloperId { get; set; }
        public int? TesterId { get; set; }

        public string Short { get; set; }
        public string Description { get; set; }
        public IssueStatus Status { get; set; }

        public virtual Project Project { get; set; }
        public virtual User Developer { get; set; }
        public virtual User Tester { get; set; }
    }
}