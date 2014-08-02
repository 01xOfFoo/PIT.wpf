using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using PIT.Business.Entities;
using PIT.WPF.ViewModels.Issues;

namespace PIT.WPF.SampleData
{
    [ExcludeFromCodeCoverage]
    public class SampleIssueHeaderAreaViewModel
    {
        public SampleIssueHeaderAreaViewModel()
        {
            IEnumerable<IssueStatusViewModel> stati = (from IssueStatus e in Enum.GetValues(typeof(IssueStatus))
                select new IssueStatusViewModel(e)).ToList();
            Status = new IssueStatusListViewModel(null, null);
            foreach (var status in stati)
            {
                Status.Add(status);
            }
            Status[0].IsSelected = true;
        }

        public IssueStatusListViewModel Status { get; set; }
    }
}