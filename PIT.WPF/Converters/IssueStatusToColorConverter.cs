using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using PIT.Business.Entities;

namespace PIT.WPF.Converters
{
    public class IssueStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (IssueStatus) value;
            Color color;

            switch (status)
            {
                case IssueStatus.Done:
                    color = Colors.Green;
                    break;
                case IssueStatus.Finished:
                    color = Colors.Black;
                    break;
                case IssueStatus.InDevelopment:
                    color = Colors.LightSeaGreen;
                    break;
                case IssueStatus.InTest:
                    color = Colors.MediumSeaGreen;
                    break;
                case IssueStatus.Open:
                    color = Colors.Gold;
                    break;
                case IssueStatus.ReadyForTesting:
                    color = Colors.LimeGreen;
                    break;
                case IssueStatus.Reopened:
                    color = Colors.OrangeRed;
                    break;
                default:
                    color = Colors.Gray;
                    break;
            }

            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}