using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.Commands
{
    [Export]
    public class AddIssueCommand : Command
    {
        private readonly IWindowManager _windowManager;
        private readonly IIssueDialogViewModel _issueDialogViewModel;

        [ImportingConstructor]
        public AddIssueCommand(IWindowManager windowManager, IIssueDialogViewModel issueDialogViewModel)
        {
            _windowManager = windowManager;
            _issueDialogViewModel = issueDialogViewModel;
        }

        public override void Execute(object parameter)
        {
            _windowManager.ShowDialog(_issueDialogViewModel);
        }
    }
}
