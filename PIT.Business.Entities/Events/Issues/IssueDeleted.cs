namespace PIT.Business.Entities.Events.Issues
{
    public class IssueDeleted
    {
        public IssueDeleted(Issue issue)
        {
            Issue = issue;
        }

        public Issue Issue { get; set; }
    }
}