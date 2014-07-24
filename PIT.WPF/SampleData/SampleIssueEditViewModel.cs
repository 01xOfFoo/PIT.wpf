using System;
using PIT.WPF.ViewModels.Issues;

namespace PIT.WPF.SampleData
{
    class SampleIssueEditViewModel
    {
        public string DialogHeaderCaption
        {
            get { return "Add/Edit issue"; }
        }

        public string DialogSubHeaderCaption
        {
            get { return "test text"; }
        }

        public IssueViewModel Model
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
