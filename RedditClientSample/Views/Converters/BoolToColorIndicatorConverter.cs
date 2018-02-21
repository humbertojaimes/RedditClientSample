using System;
using System.Globalization;
using Xamarin.Forms;

namespace RedditClientSample.Views.Converters
{
    public class BoolToColorIndicatorConverter:IValueConverter
    {
        public BoolToColorIndicatorConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value ? Color.Red : Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
