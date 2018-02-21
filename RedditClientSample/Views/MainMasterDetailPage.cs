using System;
using Xamarin.Forms;

namespace RedditClientSample.Views
{
    public class MainMasterDetailPage : MasterDetailPage
    {
        public MainMasterDetailPage()
        {
            MasterBehavior = MasterBehavior.SplitOnLandscape;
            Master = new NavigationPage(new EntriesListPage())
            { Title = "Menú", Icon = "menu.png" };
            Detail = new NavigationPage(new EntryDetailPage()); 
        }
    }
}

