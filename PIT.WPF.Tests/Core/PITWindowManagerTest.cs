using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.Business.Entities;
using PIT.WPF.Core;

namespace PIT.WPF.Tests.Core.Core
{
    [TestClass]
    public class PITWindowManagerTest
    {
        [TestMethod]
        public void WindowManager_Positions_MainWindow_On_Screen_Center_On_1024_768()
        {
            PITWindowManager windowManager = new PITWindowManager(1024, 768);
            WindowLocation windowLocation = windowManager.GetCenteredWindowLocation(1024, 768);

            Assert.AreEqual(windowLocation.Left, 25, "left window position not valid");
            Assert.AreEqual(windowLocation.Top, 25, "top window position not valid");
            Assert.AreEqual(windowLocation.Width, 974, "desired width of window not valid");
            Assert.AreEqual(windowLocation.Height, 718, "desired height of window not valid");
        }

        [TestMethod]
        public void WindowManager_Positions_MainWindow_On_Screen_Center_On_1280_1024()
        {
            PITWindowManager windowManager = new PITWindowManager(1280, 1024);
            WindowLocation windowLocation = windowManager.GetCenteredWindowLocation(1024, 768);

            Assert.AreEqual(windowLocation.Left, 128, "left window position not valid");
            Assert.AreEqual(windowLocation.Top, 128, "top window position not valid");
            Assert.AreEqual(windowLocation.Width, 1024, "desired width of window not valid");
            Assert.AreEqual(windowLocation.Height, 768, "desired height of window not valid");
        }

        [TestMethod]
        public void WindowManager_Positions_MainWindow_On_Screen_Center_On_1920_1080()
        {
            PITWindowManager windowManager = new PITWindowManager(1920, 1080);
            WindowLocation windowLocation = windowManager.GetCenteredWindowLocation(1024, 768);

            Assert.AreEqual(windowLocation.Left, 448, "left window position not valid");
            Assert.AreEqual(windowLocation.Top, 156, "top window position not valid");
            Assert.AreEqual(windowLocation.Width, 1024, "desired width of window not valid");
            Assert.AreEqual(windowLocation.Height, 768, "desired height of window not valid");
        }
    }
}
