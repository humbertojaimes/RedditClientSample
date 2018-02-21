using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RedditClientSample.Models;

namespace RedditClientSample.Interfaces
{
    public interface IRedditService
    {

        Task<IEnumerable<RedditEntry>> GetTopEntries();
        Task<IEnumerable<RedditEntry>> GetNextEntries(string lastEntryName);
    }
}
