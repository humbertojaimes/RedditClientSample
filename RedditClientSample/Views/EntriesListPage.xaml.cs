using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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


        async void Handle_Tapped(object sender, TappedEventArgs e)
        {
            
            var context = BindingContext as EntriesListViewModel;
            Image image = sender as Image;
            var cell = image.Parent.Parent as ViewCell;
            cell.View.FadeTo(0, 1000, Easing.Linear);
            await Task.Delay(1100);
            var selectedEntry = cell.BindingContext as RedditEntry;
            context.TopEntries.Remove(selectedEntry);
        }

        async void DismissAll_Click_Handle(object sender, EventArgs e)
        {

            var context = BindingContext as EntriesListViewModel;
            Button button = sender as Button;
            var mainStack = button.Parent as View; 
            mainStack.FadeTo(0, 1500, Easing.Linear);
            await Task.Delay(1600);
            var selectedEntry = mainStack.BindingContext as RedditEntry;
            context.TopEntries.Clear();
            mainStack.FadeTo(1, 1500, Easing.Linear);
        }

        void Handle_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var entry = e.Item as RedditEntry;
            var context = BindingContext as EntriesListViewModel;
            if(context.TopEntries.IndexOf(entry) == context.TopEntries.Count-1)
            {
                context.GetNextEntriesCommand.Execute(entry);  
            }
        } 

    }
}
