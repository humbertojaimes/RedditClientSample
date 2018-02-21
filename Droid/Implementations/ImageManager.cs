
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Java.IO;
using RedditClientSample.Droid.Implementations;
using RedditClientSample.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(ImageManager))]
namespace RedditClientSample.Droid.Implementations
{
    public class ImageManager : IImageManager
    {

        public  async Task<bool> SaveImage(byte[] image)
        {
            bool wasSaved = false;

            try
            {
                var filename = System.IO.Path.Combine(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures).ToString(), "NewFolder");
                Directory.CreateDirectory(filename);
                filename = System.IO.Path.Combine(filename, "filename.jpg");
                using (var fileOutputStream = new FileOutputStream(filename))
                {
                    await fileOutputStream.WriteAsync(image);
                }
                wasSaved = true;
            }
            catch (System.Exception ex)
            {
                wasSaved = false;
            }


            return wasSaved;
        }
    }
}
