using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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


        bool useMockData = false;
        IRedditService redditService;

        public EntriesListViewModel()
        {
            InitViewModel();
        }

        async Task InitViewModel()
        {
            if (useMockData)
                redditService = new LocalRedditService();
            else
                redditService = new RestRedditService();

            Title = "Top Reddit Entries";
            TopEntries = new ObservableCollection<RedditEntry>(await redditService.GetTopEntries());
     
        }
    }
}
