using System;
using System.ComponentModel.Composition;
using PIT.Business.Entities;
using PIT.WPF.Core.Contracts;

namespace PIT.WPF.Core
{
    [Export(typeof(IPITWindowManager))]
    public class PITWindowManager : IPITWindowManager
    {
    	private readonly double _primaryScreenWidth;
		private readonly double _primaryScreenHeight;

        public PITWindowManager() : this(System.Windows.SystemParameters.PrimaryScreenWidth, 
                                            System.Windows.SystemParameters.PrimaryScreenHeight)
        {
        }

        public PITWindowManager(double primaryScreenWidth, double primaryScreenHeight)
        {
            _primaryScreenWidth = primaryScreenWidth;
            _primaryScreenHeight = primaryScreenHeight;
        }

        public WindowLocation GetCenteredWindowLocation(double desiredWidth, double desiredHeight)
        {
            return GetCenteredWindow(desiredWidth, desiredHeight,
                new System.Windows.Rect(0.0, 0.0, _primaryScreenWidth, _primaryScreenHeight));
        }

        private WindowLocation GetCenteredWindow(double desiredWidth, double desiredHeight, System.Windows.Rect parentArea)
        {
            if (desiredWidth <= 1.0)
            {
                desiredWidth = parentArea.Width * desiredWidth;
            }
            if (desiredHeight <= 1.0)
            {
                desiredHeight = parentArea.Height * desiredHeight;
            }

            var windowLocation = new WindowLocation();

            windowLocation.Width = Math.Min(desiredWidth, parentArea.Width - 50.0);
            windowLocation.Height = Math.Min(desiredHeight, parentArea.Height - 50.0);
            windowLocation.Left = parentArea.Left + (parentArea.Width - windowLocation.Width) / 2.0;
            windowLocation.Top = parentArea.Top + (parentArea.Height - windowLocation.Height) / 2.0;

            return windowLocation;
        }
    }
}
