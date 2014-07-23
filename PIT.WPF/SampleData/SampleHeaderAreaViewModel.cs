using System.Diagnostics.CodeAnalysis;
using Caliburn.Micro;
using PIT.WPF.ViewModels.Header.Contracts;

namespace PIT.WPF.SampleData
{
    [ExcludeFromCodeCoverage]
    class SampleHeaderAreaViewModel : PropertyChangedBase, IHeaderAreaViewModel
    {
        public string SelectedProjectName 
        {
            get { return "PROJEKT 1"; }
        }
    }
}
