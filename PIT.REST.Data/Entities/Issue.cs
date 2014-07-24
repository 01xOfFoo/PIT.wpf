using System;
using System.ComponentModel.DataAnnotations;

namespace PIT.REST.Data.Entities
{
    public class Issue : Entity
    {
        public Issue()
        {
            Project = new Project();
            Status = IssueStatus.Open;
        }

        public string Short { get; set; }
        public string Description { get; set; }
        public IssueStatus Status { get; set; }

        public Project Project { get; set; }
    }
}