using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IIssueEditViewModel))]
    public class IssueEditViewModel : PropertyChangedBase, IIssueEditViewModel
    {
    }
}
