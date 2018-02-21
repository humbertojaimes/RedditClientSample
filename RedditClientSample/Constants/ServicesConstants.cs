using System;
namespace RedditClientSample.Constants
{
    public class ServicesConstants
    {
        public const string apiUrl= "https://www.reddit.com";
        public const string topEntriesPath = "/top/.json?limit=";
        public const string nextEntriesPath = "/top/.json?limit={0}&after={1}";
        public const int pageLimit = 10;
    }
}
