using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.Commands
{
    [Export]
    public class AddIssueCommand : Command
    {
        private readonly IWindowManager _windowManager;
        private readonly IIssueEditViewModel _issueEditViewModel;

        [ImportingConstructor]
        public AddIssueCommand(IWindowManager windowManager, IIssueEditViewModel issueEditViewModel)
        {
            _windowManager = windowManager;
            _issueEditViewModel = issueEditViewModel;
        }

        public override void Execute(object parameter)
        {
            _windowManager.ShowDialog(_issueEditViewModel);
        }
    }
}
