using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            TopRedditEntriesResponse redditApiResponse = null;
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
                    Uri image = null;
                    bool hasImage = false;
                    Uri.TryCreate(child.data.thumbnail, UriKind.Absolute, out thumbnailUri);
                    if (hasImage = child.data.domain.Contains("imgur"))
                        Uri.TryCreate(child.data.url, UriKind.Absolute, out image);



                    var newEntry = new RedditEntry()
                    {
                        Author = child.data.author,
                        CommentsNumber = child.data.num_comments,
                        Thumbnail = thumbnailUri,
                        Createdutc = child.data.created_utc.UnixTimeStampToDateTime(),
                        Title = child.data.title,
                        Image = image,
                        Name = child.data.name,
                        HasImage = hasImage
                    };


                    result.Add(newEntry);
                }
            }
            return result;
        }

    }
}
