using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using RedditClientSample.Interfaces;
using RedditClientSample.Models;
using RedditClientSample.Services.ResponseEntities;

namespace RedditClientSample.Services.LocalServices
{
    public class LocalRedditService : IRedditService
    {
        public  IEnumerable<RedditEntry> GetTopEntries()
        {
            
            var topEntriesLocalContent = Helpers.LocalFilesHelper.ReadFileInPackage(Constants.LocalFiles.TopEntriesFile);
            if(!string.IsNullOrEmpty(topEntriesLocalContent)) 
            {
                var redditApiResponse = JsonConvert.DeserializeObject<Rootobject>(topEntriesLocalContent);
               
                if(redditApiResponse?.data?.children !=null)
                {
                    foreach (var child in redditApiResponse.data.children)
                    {
                        var newEntry = new RedditEntry()
                        {
                            Author = child.data.author,
                            CommentsNumber = child.data.num_comments,
                            Thumbnail = child.data.thumbnail,
                            Createdutc= child.data.created_utc,
                            Title = child.data.title
                        };
                        yield return newEntry;
                    }
                }

   
            }

        }
    }
}
