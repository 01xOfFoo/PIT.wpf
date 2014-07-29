using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace PIT.WPF.Converters
{
    public class EnumToArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = new ArrayList();
            Array enumValues = Enum.GetValues(value.GetType());

            foreach (Enum enumValue in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(enumValue, EnumExtension.GetEnumDescription(enumValue)));
            }

            return list;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}