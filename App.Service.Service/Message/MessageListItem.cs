namespace App.Service.Message
{
    using App.Common;
    using System;

    public class MessageListItem
    {
        public string Message { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Id { get; set; }
        public ConnectorType ConnectorType { get; set; }
    }
}