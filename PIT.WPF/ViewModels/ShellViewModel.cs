using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;
using PIT.Business.Entities;
using PIT.WPF.Core;
using PIT.WPF.Core.Contracts;
using PIT.WPF.ViewModels.Header.Contracts;
using PIT.WPF.ViewModels.Issues.Contracts;
using PIT.WPF.ViewModels.Projects.Contracts;
using PIT.WPF.Views;

namespace PIT.WPF.ViewModels
{
    [Export(typeof(IShellViewModel))]
    public class ShellViewModel : Conductor<Screen>.Collection.AllActive, IShellViewModel
    {
        private readonly IPITWindowManager _windowManager;

        private WindowLocation _windowLocation;

        [Import]
        public IIssueAreaViewModel Issues { get; set; }

        [Import]
        public IHeaderAreaViewModel Header { get; set; }

        [Import]
        public IProjectAreaViewModel Projects { get; set; }

        [ImportingConstructor]
        public ShellViewModel(IPITWindowManager windowManager)
        {
            _windowManager = windowManager;

            DetermineWindowLocation();
            SetWindowCaption();
        }

        private string SetWindowCaption()
        {
            return DisplayName = "PIT: Project Issue Tracker";
        }

        private void DetermineWindowLocation()
        {
            _windowManager.ApplyScreenBoundaries(SystemParameters.PrimaryScreenWidth, SystemParameters.PrimaryScreenHeight);
            _windowLocation = _windowManager.GetCenteredWindowLocation(1600, 900);
        }

        protected override void OnViewAttached(object view, object context)
        {
            var shellView = (ShellView)view;
            // ReSharper disable once ObjectCreationAsStatement
            new WindowLocationPersister(shellView, _windowLocation);
        }
    }
}
