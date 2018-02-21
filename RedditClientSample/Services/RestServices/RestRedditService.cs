using System;
using System.Collections.Generic;
using RedditClientSample.Interfaces;
using RedditClientSample.Models;

namespace RedditClientSample.Services.RestServices
{
    public class RestRedditService : IRedditService
    {
        public RestRedditService()
        {
        }

        public IEnumerable<RedditEntry> GetTopEntries()
        {
            throw new NotImplementedException();
        }
    }
}
