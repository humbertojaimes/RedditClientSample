using System;
using System.Globalization;
using Xamarin.Forms;

namespace RedditClientSample.Views.Converters
{
    public class DateToElapsedHoursConverter: IValueConverter
    {
        public DateToElapsedHoursConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime time = (DateTime)value;

            var elapsedHours = Math.Round((DateTime.Now - time).TotalHours);
            return elapsedHours;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
