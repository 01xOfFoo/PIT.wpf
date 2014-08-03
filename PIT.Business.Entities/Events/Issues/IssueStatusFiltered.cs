namespace PIT.Business.Entities.Events.Issues
{
    public class IssueStatusFiltered
    {
        public IssueStatus Status;

        public IssueStatusFiltered(IssueStatus status)
        {
            Status = status;
        }
    }
}