using System.ComponentModel;

namespace PIT.Business.Entities
{
    public enum IssueStatus
    {
        Open = 0,
        Assigned = 1,
        [Description("In development")]
        InDevelopment = 2,
        [Description("Ready for testing")]
        ReadyForTesting = 3,
        [Description("In test")]
        InTest = 4,
        Done = 5,
        Reopened = 6,
        Finished = 7
    }
}