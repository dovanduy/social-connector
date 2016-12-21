namespace App.Service.Facebook
{
    public class FacebookCommentOnFeed
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public FacebookCommentOnFeed(string id, string message)
        {
            this.Id = id;
            this.Message = message;
        }
    }

}