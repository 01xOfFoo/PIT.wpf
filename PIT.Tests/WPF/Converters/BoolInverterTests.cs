using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.WPF.Converters;

namespace PIT.Tests.WPF.Converters
{
    [TestClass]
    public class BoolInverterTests
    {
        private BoolInverter _converter;

        [TestInitialize]
        public void SetUp()
        {
            _converter = new BoolInverter();
        }

        [TestMethod]
        public void ReturnsBoolean()
        {
            var value = _converter.Convert(true, typeof(bool), null, null);
            Assert.IsInstanceOfType(value, typeof(bool));
        }

        [TestMethod]
        public void InvertsTrue()
        {
            var value = (bool)_converter.Convert(true, typeof(bool), null, null);
            Assert.IsFalse(value);
        }

        [TestMethod]
        public void InvertsFalse()
        {
            var value = (bool)_converter.Convert(false, typeof(bool), null, null);
            Assert.IsTrue(value);
        }
    }
}