using System;
using System.Collections.ObjectModel;
using RedditClientSample.Interfaces;
using RedditClientSample.Models;
using RedditClientSample.Services.LocalServices;
using RedditClientSample.Services.RestServices;

namespace RedditClientSample.ViewModels
{
    public class EntriesListViewModel : MvvmHelpers.BaseViewModel
    {
        private ObservableCollection<RedditEntry> topEntries;

        public ObservableCollection<RedditEntry> TopEntries
        {
            get { return topEntries; }
            set { topEntries = value; OnPropertyChanged(); }
        }


        bool useMockData = true;
        IRedditService redditService;

        public EntriesListViewModel()
        {
            if (useMockData)
                redditService = new LocalRedditService();
            else
                redditService = new RestRedditService();

            Title = "Top Reddit Entries";
            TopEntries = new ObservableCollection<RedditEntry>(redditService.GetTopEntries());
        }
    }
}
