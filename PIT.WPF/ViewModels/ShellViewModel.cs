using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;
using Microsoft.Practices.ServiceLocation;
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
    public class ShellViewModel : Screen, IShellViewModel
    {
        private readonly IPITWindowManager _windowManager;

        private WindowLocation _windowLocation;

        [ImportingConstructor]
        public ShellViewModel(IPITWindowManager windowManager)
        {
            _windowManager = windowManager;
            _windowManager.OnActivatePage += OnOnActivatePage;

            DetermineWindowLocation();
            SetWindowCaption();

            ActivatePage(ServiceLocator.Current.GetInstance<IIssueAreaViewModel>());
        }

        public object Content { get; set; }

        [Import]
        public IHeaderAreaViewModel Header { get; set; }

        [Import]
        public IProjectAreaViewModel Projects { get; set; }

        private void OnOnActivatePage(object sender, object o)
        {
            ActivatePage(o);
        }

        private void SetWindowCaption()
        {
            DisplayName = "PIT: Project Issue Tracker";
        }

        private void DetermineWindowLocation()
        {
            _windowManager.ApplyScreenBoundaries(SystemParameters.PrimaryScreenWidth,
                SystemParameters.PrimaryScreenHeight);
            _windowLocation = _windowManager.GetCenteredWindowLocation(1100, 700);
        }

        protected override void OnViewAttached(object view, object context)
        {
            var shellView = (ShellView) view;
            // ReSharper disable once ObjectCreationAsStatement
            new WindowLocationPersister(shellView, _windowLocation);
        }

        public void ActivatePage(object page)
        {
            Content = page;
            NotifyOfPropertyChange(() => Content);
        }
    }
}