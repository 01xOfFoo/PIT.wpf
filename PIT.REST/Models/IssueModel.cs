using PIT.REST.Data.Entities;

namespace PIT.REST.Models
{
    public class IssueModel : BaseModel
    {
        public string Short { get; set; }
        public string Description { get; set; }
        public IssueStatus Status { get; set; }
        public ProjectModel Project { get; set; }
    }
}