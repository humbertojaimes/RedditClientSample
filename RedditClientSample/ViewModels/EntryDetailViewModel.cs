using System;
using System.Net.Http;
using System.Windows.Input;
using RedditClientSample.Models;
using Xamarin.Forms;

namespace RedditClientSample.ViewModels
{
    public class EntryDetailViewModel : MvvmHelpers.BaseViewModel
    {
        static HttpClient client;

        private RedditEntry selectedRedditEntry;

        public RedditEntry SelectedRedditEntry
        {
            get { return selectedRedditEntry; }
            set
            {
                SetProperty(ref selectedRedditEntry, value);
                IsSelected = true;
                HasImage = value.HasImage;
            }
        }

      
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                SetProperty(ref isSelected, value);
            }
        }

        private bool hasImage;

        public bool HasImage
        {
            get { return hasImage; }
            set
            {
                SetProperty(ref hasImage, value);
            }
        }

        public ICommand ViewImageCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (selectedRedditEntry.Image != null)
                    Device.OpenUri(selectedRedditEntry.Image);
                });
            }
        }

        public ICommand SaveImageCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (selectedRedditEntry.Thumbnail == null)
                        return;
                        
                    if (client == null)
                        client = new HttpClient();

                    var image = await client.GetByteArrayAsync(selectedRedditEntry.Thumbnail);

                   await DependencyService.Get<Interfaces.IImageManager>().SaveImage(image);
                });
            }
        }

        public EntryDetailViewModel()
        {
            Title = "Entry Detail";
            Icon = "Menu";
            IsSelected = false;
            HasImage = false;
        }
    }
}
