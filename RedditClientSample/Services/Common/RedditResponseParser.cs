using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedditClientSample.Extensions;
using RedditClientSample.Models;
using RedditClientSample.Services.ResponseEntities;

namespace RedditClientSample.Services.Common
{
    public class RedditResponseParser
    {

        public async static Task<IEnumerable<RedditEntry>> ParseTopEntriesResponse(string jsonResponse)
        {
            TopRedditEntriesResponse redditApiResponse=null;
            ObservableCollection<RedditEntry> result = null;
            try
            {
                 redditApiResponse = JsonConvert.DeserializeObject<TopRedditEntriesResponse>(jsonResponse);

            }
            catch (Exception ex)
            {

            }
           
            if (redditApiResponse?.data?.children != null)
            {
                result = new ObservableCollection<RedditEntry>();
                foreach (var child in redditApiResponse.data.children)
                {

                    Uri thumbnailUri = null;
                    Uri.TryCreate(child.data.thumbnail, UriKind.Absolute, out thumbnailUri);

                    var newEntry = new RedditEntry()
                    {
                        Author = child.data.author,
                        CommentsNumber = child.data.num_comments,
                        Thumbnail = thumbnailUri,
                        Createdutc = child.data.created_utc.UnixTimeStampToDateTime(),
                        Title = child.data.title
                    };


                    result.Add(newEntry);
                }
            }
            return result;
        }

    }
}
