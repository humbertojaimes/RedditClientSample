using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RedditClientSample.Interfaces;
using RedditClientSample.Models;

namespace RedditClientSample.Services.RestServices
{
    public class RestRedditService : BaseRestApiService, IRedditService
    {
        public RestRedditService()
        {
        }

        public async Task<IEnumerable<RedditEntry>> GetTopEntries()
        {
            string requestUri = $"{Constants.ServicesConstants.apiUrl}{Constants.ServicesConstants.topEntriesPath}{Constants.ServicesConstants.pageLimit}";
            InitHttpclient();
            var apiResult = await client?.GetStringAsync(requestUri);

            if (!string.IsNullOrEmpty(apiResult))
            {
                return await Common.RedditResponseParser.ParseTopEntriesResponse(apiResult);
            }
            return null;
        }

        public async Task<IEnumerable<RedditEntry>> GetNextEntries(string lastEntryName)
        {
            string query = string.Format(Constants.ServicesConstants.nextEntriesPath, Constants.ServicesConstants.pageLimit, lastEntryName);
            string requestUri = $"{Constants.ServicesConstants.apiUrl}{query}";
            InitHttpclient();
            var apiResult = await client?.GetStringAsync(requestUri);

            if (!string.IsNullOrEmpty(apiResult))
            {
                return await Common.RedditResponseParser.ParseTopEntriesResponse(apiResult);
            }
            return null;
        }

    }
}
