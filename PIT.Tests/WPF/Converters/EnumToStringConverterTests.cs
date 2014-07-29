using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PIT.WPF.Converters;

namespace PIT.Tests.WPF.Converters
{
    [TestClass]
    public class EnumToStringConverterTests
    {
        private const string EnumDescription = "Enum description";

        private EnumToStringConverter _converter;

        private object ConvertEnum(EnumTest value)
        {
            return _converter.Convert(value, typeof(EnumTest), null, null);
        }

        [TestInitialize]
        public void SetUp()
        {
            _converter = new EnumToStringConverter();
        }

        [TestMethod]
        public void ReturnTypeIsString()
        {
            object enumList = ConvertEnum(EnumTest.Enum1);
            Assert.IsInstanceOfType(enumList, typeof(string));
        }

        [TestMethod]
        public void ConvertsEnumToString()
        {
            var enumString = (string) ConvertEnum(EnumTest.Enum1);
            Assert.AreEqual("Enum1", enumString);
        }

        [TestMethod]
        public void DeterminesDescriptionsOfEnumValuesIfDefined()
        {
            var enumString = (string) ConvertEnum(EnumTest.Enum2);
            Assert.AreEqual(EnumDescription, enumString);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void FailsIfConvertBackIsInvoked()
        {
            _converter.ConvertBack(EnumTest.Enum1, typeof(EnumTest), null, null);
        }

        private enum EnumTest
        {
            Enum1,
            [System.ComponentModel.Description(EnumDescription)] Enum2
        }
    }
}