using System;
using System.Diagnostics.CodeAnalysis;
using PIT.WPF.ViewModels.Projects;

namespace PIT.WPF.SampleData
{
    [ExcludeFromCodeCoverage]
    class SampleProjectEditViewModel
    {
        public string ProjectDialogHeaderCaption
        {
            get { return "Add/Edit project"; }
        }

        public string ProjectDialogSubHeaderCaption
        {
            get { return "test text"; }
        }

        public ProjectViewModel Model
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
