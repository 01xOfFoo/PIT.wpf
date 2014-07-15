using Caliburn.Micro;
using PIT.WPF.ViewModels.Header.Contracts;
using PIT.WPF.ViewModels.Issues.Contracts;
using PIT.WPF.ViewModels.Projects.Contracts;

namespace PIT.WPF.ViewModels.Contracts
{
    public interface IShellViewModel : IScreen
    {
        IProjectAreaViewModel Projects { get; set; }
        IIssueAreaViewModel Issues { get; set; }
        IHeaderAreaViewModel Header { get; set; }
    }
}
