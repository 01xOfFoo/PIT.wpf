using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.WPF.Converters;

namespace PIT.Tests.WPF.Converters
{
    [TestClass]
    public class BoolToVisibleCollapsedConverterTests
    {
        private BoolToVisibleCollapsedConverter _converter;

        [TestInitialize]
        public void SetUp()
        {
            _converter = new BoolToVisibleCollapsedConverter();
        }

        [TestMethod]
        public void ReturnsVisibility()
        {
            var value = _converter.Convert(true, typeof(Visibility), null, null);
            Assert.IsInstanceOfType(value, typeof(Visibility));
        }

        [TestMethod]
        public void ConvertsTrueToVisible()
        {
            var value = (Visibility)_converter.Convert(true, typeof(Visibility), null, null);
            Assert.AreEqual(Visibility.Visible, value);
        }

        [TestMethod]
        public void ConvertsFalseToCollapsed()
        {
            var value = (Visibility)_converter.Convert(false, typeof(Visibility), null, null);
            Assert.AreEqual(Visibility.Collapsed, value);
        }
    }
}