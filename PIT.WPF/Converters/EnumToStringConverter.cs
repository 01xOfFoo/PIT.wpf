using System;
using System.Globalization;
using System.Windows.Data;
using PIT.WPF.Helper;

namespace PIT.WPF.Converters
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumValue = (Enum) value;
            return EnumExtension.GetEnumDescription(enumValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}