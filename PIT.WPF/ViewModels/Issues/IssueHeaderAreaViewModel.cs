using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.Commands;
using PIT.WPF.ViewModels.Issues.Contracts;

namespace PIT.WPF.ViewModels.Issues
{
    [Export(typeof(IIssueHeaderAreaViewModel))]
    public class IssueHeaderAreaViewModel : PropertyChangedBase, IIssueHeaderAreaViewModel
    {
        private readonly AddIssueCommand _addIssueCommand;

        public AddIssueCommand AddIssueCommand
        {
            get
            {
                return this._addIssueCommand;
            }
        }

        [ImportingConstructor]
        public IssueHeaderAreaViewModel(AddIssueCommand addIssueCommand)
        {
            _addIssueCommand = addIssueCommand;
        }
    }
}
