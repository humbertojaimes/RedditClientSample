using System;

using Xamarin.Forms;

namespace RedditClientSample.Views
{
    public class EntryDetailPage : ContentPage
    {
        public EntryDetailPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

