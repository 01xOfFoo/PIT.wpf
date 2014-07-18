using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIT.WPF.ViewModels.Projects;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.SampleData
{
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
