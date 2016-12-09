namespace App.Service.Twitter
{
    public class ShareTwitterComment
    {
        public string Status { get; set; }
        public ShareTwitterComment(string status)
        {
            this.Status = status;
        }
    }
}