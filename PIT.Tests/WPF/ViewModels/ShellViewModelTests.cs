using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PIT.WPF.Core;
using PIT.WPF.ViewModels;

namespace PIT.Tests.WPF.ViewModels
{
    [TestClass]
    public class ShellViewModelTests
    {
        private ShellViewModel _viewModel;
        private Mock<PITWindowManager> _pitWindowManager;

        [TestInitialize]
        public void SetUp()
        {
            _pitWindowManager = new Mock<PITWindowManager>();
            _viewModel = new ShellViewModel(_pitWindowManager.Object);
        }

        [TestMethod]
        public void DisplaysCorrectWindowCaption()
        {
            Assert.AreEqual("PIT: Project Issue Tracker", _viewModel.DisplayName);
        }
    }
}
