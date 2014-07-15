using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.Business.Entities;
using PIT.WPF.Core;
using PIT.WPF.Core.Contracts;
using PIT.WPF.ViewModels.Contracts;
using PIT.WPF.ViewModels.Header.Contracts;
using PIT.WPF.ViewModels.Issues.Contracts;
using PIT.WPF.ViewModels.Projects.Contracts;
using PIT.WPF.Views;

namespace PIT.WPF.ViewModels
{
    [Export(typeof(IShellViewModel))]
    public class ShellViewModel : Conductor<IScreen>.Collection.AllActive, IShellViewModel, IPartImportsSatisfiedNotification
    {
        private readonly IPITWindowManager _windowManager;

        private WindowLocation _windowLocation;

        [Import]
        public IIssueAreaViewModel Issues { get; set; }

        [Import] 
        public IHeaderAreaViewModel Header { get; set; }

        [Import]
        public IProjectAreaViewModel Projects { get; set; }

        public ShellViewModel(IPITWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public void OnImportsSatisfied()
        {
            _windowLocation = _windowManager.GetCenteredWindowLocation(1024, 768);
        }

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);

            var shellView = (ShellView)view;
// ReSharper disable once ObjectCreationAsStatement
            new WindowLocationPersister(shellView, _windowLocation);
        }
    }
}
