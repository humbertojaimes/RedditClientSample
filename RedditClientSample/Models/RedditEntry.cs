﻿using System;
using MvvmHelpers;
using Newtonsoft.Json;

namespace RedditClientSample.Models
{
    public class RedditEntry: ObservableObject
    {

        private string title;

        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set
            {
                SetProperty(ref title, value);
            }
        }

        private string author;

        [JsonProperty("author")]
        public string Author
        {
            get { return author; }
            set
            {
                SetProperty(ref author, value);
            }
        }

        private DateTime createdUtc;

        [JsonProperty("created_utc")]
        public DateTime Createdutc
        {
            get { return createdUtc; }
            set
            {
                SetProperty(ref createdUtc, value);
            }
        }

        private Uri thumbnail;

        [JsonProperty("thumbnail")]
        public Uri Thumbnail
        {
            get { return thumbnail; }
            set
            {
                SetProperty(ref thumbnail, value);
            }
        }

        private int commentsNumber;

        [JsonProperty("num_comments")]
        public int CommentsNumber
        {
            get { return commentsNumber; }
            set
            {
                SetProperty(ref commentsNumber, value);
            }
        }

        private bool wasReaded;

        [JsonIgnore]
        public bool WasReaded
        {
            get { return wasReaded; }
            set
            {
                SetProperty(ref wasReaded, value);
            }
        }

    }
}
