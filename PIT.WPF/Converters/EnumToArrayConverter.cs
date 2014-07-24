using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace PIT.WPF.Converters
{
    public class EnumToArrayConverter : IValueConverter
    {
        private static string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = new ArrayList();
            var enumValues = Enum.GetValues(value.GetType());

            foreach (Enum enumValue in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(enumValue, GetEnumDescription(enumValue)));
            }

            return list; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}