﻿namespace App.Service.Message
{
    using Common.Connector;

    public class PostMessageRequest : IPostMessage
    {
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}