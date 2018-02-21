using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using Newtonsoft.Json;
using RedditClientSample.Interfaces;
using RedditClientSample.Models;
using RedditClientSample.Services.ResponseEntities;
using RedditClientSample.Extensions;

namespace RedditClientSample.Services.LocalServices
{
    public class LocalRedditService : IRedditService
    {
        public IEnumerable<RedditEntry> GetTopEntries()
        {

            var topEntriesLocalContent = Helpers.LocalFilesHelper.ReadFileInPackage(Constants.LocalFiles.TopEntriesFile);
            if (!string.IsNullOrEmpty(topEntriesLocalContent))
            {
                var redditApiResponse = JsonConvert.DeserializeObject<Rootobject>(topEntriesLocalContent);

                if (redditApiResponse?.data?.children != null)
                {
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


                        yield return newEntry;
                    }
                }


            }

        }
    }
}
