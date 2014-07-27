using System;
using System.ComponentModel.DataAnnotations;

namespace PIT.REST.Data.Entities
{
    public class Issue : Entity
    {
        public int ProjectId { get; set; }

        public string Short { get; set; }
        public string Description { get; set; }
        public IssueStatus Status { get; set; }

        public virtual Project Project { get; set; }
    }
}