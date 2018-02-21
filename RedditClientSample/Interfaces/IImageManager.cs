using System;
using System.Threading.Tasks;

namespace RedditClientSample.Interfaces
{
    public interface IImageManager
    {
        Task<bool> SaveImage(byte[] Image);

    }
}
