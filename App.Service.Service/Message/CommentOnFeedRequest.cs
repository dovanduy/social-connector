namespace App.Service.Message
{
    public class CommentOnFeedRequest
    {
        public string Id { get; set; }
        public string Comment { get; set; }
        public CommentOnFeedRequest(string id, string message)
        {
            this.Id = id;
            this.Comment = message;
        }
    }
}