namespace App.Service.Message
{
    using Common.Connector;

    public class PostMessageRequest : IPostMessage
    {
        public string Content { get; set; }
        public PostMessageRequest()
        {
        }
        public PostMessageRequest(string messageContent)
        {
            this.Content = messageContent;
        }
    }
}