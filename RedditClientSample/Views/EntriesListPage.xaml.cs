using System;
using System.Collections.Generic;
using RedditClientSample.Models;
using RedditClientSample.ViewModels;
using Xamarin.Forms;

namespace RedditClientSample.Views
{
    public partial class EntriesListPage : ContentPage
    {
        public EntriesListPage()
        {
            InitializeComponent();
        }


        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var selectedEntry = e.Item as RedditEntry;
                selectedEntry.WasReaded = true;
                var detailPage = ((Application.Current.MainPage as MasterDetailPage).Detail 
                                  as NavigationPage).CurrentPage as EntryDetailPage;
                var detailBindingContext = detailPage.BindingContext as EntryDetailViewModel;
                detailBindingContext.SelectedRedditEntry = selectedEntry;
                (sender as ListView).SelectedItem = null;
            }
        }
    }
}
