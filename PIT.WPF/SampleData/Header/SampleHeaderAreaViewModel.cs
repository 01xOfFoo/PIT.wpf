using System.Diagnostics.CodeAnalysis;
using Caliburn.Micro;
using PIT.WPF.ViewModels.Header.Contracts;

namespace PIT.WPF.SampleData.Header
{
    [ExcludeFromCodeCoverage]
    internal class SampleHeaderAreaViewModel : PropertyChangedBase, IHeaderAreaViewModel
    {
        public string SelectedProjectName
        {
            get { return "PROJEKT 1"; }
        }
    }
}