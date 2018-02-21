using System;
using RedditClientSample.Models;

namespace RedditClientSample.ViewModels
{
    public class EntryDetailViewModel : MvvmHelpers.BaseViewModel
    {

        private RedditEntry selectedRedditEntry;

        public RedditEntry SelectedRedditEntry
        {
            get { return selectedRedditEntry; }
            set
            {
                SetProperty(ref selectedRedditEntry, value);
            }
        }

        public EntryDetailViewModel()
        {
            Title = "Entry Detail";
            Icon = "Menu";

        }
    }
}
