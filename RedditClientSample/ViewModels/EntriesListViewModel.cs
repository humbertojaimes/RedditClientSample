﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RedditClientSample.Interfaces;
using RedditClientSample.Models;
using RedditClientSample.Services.LocalServices;
using RedditClientSample.Services.RestServices;
using System.Windows.Input;
using Xamarin.Forms;

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

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                SetProperty(ref isRefreshing, value);
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (!IsBusy)
                    {
                        IsRefreshing = true;
                        IsBusy = true;
                        if (useMockData)
                            redditService = new LocalRedditService();
                        else
                            redditService = new RestRedditService();

                        Title = "Top Reddit Entries";
                        TopEntries = new ObservableCollection<RedditEntry>(await redditService.GetTopEntries());
                        IsRefreshing = false;
                        IsBusy = false;
                    }
                });
            }
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
