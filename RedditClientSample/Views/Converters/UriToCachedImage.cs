using System;
using System.Globalization;
using Xamarin.Forms;

namespace RedditClientSample.Views.Converters
{
    public class UriToCachedImage : IValueConverter
    {
        public UriToCachedImage()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = new UriImageSource
            {
                Uri = value != null ? new Uri(value.ToString())
                    : new Uri("https://i.redditmedia.com/iDdntscPf-nfWKqzHRGFmhVxZm4hZgaKe5oyFws-yzA.png?w=720&s=eea57f8eef5197981852a07ad917769e")
                    ,
                CachingEnabled = true,
                CacheValidity = TimeSpan.FromDays(2)
            };

            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}
