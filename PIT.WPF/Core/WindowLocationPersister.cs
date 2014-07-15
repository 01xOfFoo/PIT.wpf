using System.ComponentModel.Composition;
using System.Windows;
using PIT.Business.Entities;

namespace PIT.WPF.Core
{
    [Export(typeof(WindowLocationPersister))]
    public class WindowLocationPersister
    {
        private readonly WindowLocation _location;

        public WindowLocationPersister(Window mainWindow, WindowLocation location)
        {
            _location = location;
            Restore(mainWindow);
        }

        private void Restore(Window window)
        {
            window.SizeToContent = SizeToContent.Manual;
            window.Left = _location.Left;
            window.Top = _location.Top;
            window.Width = _location.Width;
            window.Height = _location.Height;
        }
    }
}
