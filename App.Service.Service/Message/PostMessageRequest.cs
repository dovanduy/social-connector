namespace App.Service.Message
{
    using App.Common.Connector.Facebook;

    public class PostMessageRequest : IFacebookPostMessage
    {
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}