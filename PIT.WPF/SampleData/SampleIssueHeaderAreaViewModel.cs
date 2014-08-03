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
        }

        public IssueStatusFilterViewModel Statuses { get; set; }
    }
}