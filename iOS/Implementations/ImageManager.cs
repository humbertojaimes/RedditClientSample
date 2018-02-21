using System;
using System.Threading.Tasks;
using CoreImage;
using RedditClientSample.Interfaces;
using RedditClientSample.iOS.Implementations;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(ImageManager))]
namespace RedditClientSample.iOS.Implementations
{
    public class ImageManager:IImageManager
    {
       
        private TaskCompletionSource<bool> savetcs;

        public async Task<bool> SaveImage(byte[] Image)
        {
            savetcs = new TaskCompletionSource<bool>();
            bool wasSaved = false;

            var someImage = new UIImage(Foundation.NSData.FromArray(Image));;
            try
            {
                someImage.SaveToPhotosAlbum((image, error) => {
                    if (error != null)
                        wasSaved = false;
                    else
                        wasSaved = true;
                     savetcs.TrySetResult(wasSaved);
                });
            }
            catch (Exception ex)
            {
                wasSaved = false;
                savetcs.TrySetResult(wasSaved);
            }


            return await savetcs.Task;
        }
    }
}
