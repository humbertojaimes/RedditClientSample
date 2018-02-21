using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Newtonsoft.Json;
using RedditClientSample.Interfaces;
using RedditClientSample.Models;
using RedditClientSample.Services.ResponseEntities;
using RedditClientSample.Extensions;
using System.Threading.Tasks;

namespace RedditClientSample.Services.LocalServices
{
    public class LocalRedditService : IRedditService
    {
        public Task<IEnumerable<RedditEntry>> GetTopEntries()
        {

            var topEntriesLocalContent = Helpers.LocalFilesHelper.ReadFileInPackage(Constants.LocalFiles.TopEntriesFile);
            if (!string.IsNullOrEmpty(topEntriesLocalContent))
            {
                return Common.RedditResponseParser.ParseTopEntriesResponse(topEntriesLocalContent);
            }
            return null;
        }
    }
}
