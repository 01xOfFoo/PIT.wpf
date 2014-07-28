using System;
using PIT.Business.Entities;

namespace PIT.WPF.SampleData
{
    internal class SampleIssueEditViewModel
    {
        public string DialogHeaderCaption
        {
            get { return "Add/Edit issue"; }
        }

        public string DialogSubHeaderCaption
        {
            get { return "test text"; }
            set { throw new NotImplementedException(); }
        }

        public string Short
        {
            get { return "default short"; }
            set { throw new NotImplementedException(); }
        }

        public string Description
        {
            get { return "default description"; }
            set { throw new NotImplementedException(); }
        }

        public IssueStatus Status
        {
            get { return IssueStatus.Assigned; }
            set { throw new NotImplementedException(); }
        }
    }
}