using System;
using System.Net.Http;

namespace RedditClientSample.Services.RestServices
{
    public abstract class BaseRestApiService 
    {
        protected static HttpClient client;


        protected void InitHttpclient()
        {
            if (client == null)
                client = new HttpClient();
        }
    }
}
