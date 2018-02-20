using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RedditClientSample.Models;

namespace RedditClientSample.Interfaces
{
    public interface IRedditService
    {

        IEnumerable<RedditEntry> GetTopEntries();
    }
}
