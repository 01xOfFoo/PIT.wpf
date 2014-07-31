namespace PIT.Business.Entities.Events.Issues
{
    public class FilterIssueStatus
    {
        public bool Filter;
        public IssueStatus Status;

        public FilterIssueStatus(IssueStatus status, bool filter)
        {
            Status = status;
            Filter = filter;
        }
    }
}