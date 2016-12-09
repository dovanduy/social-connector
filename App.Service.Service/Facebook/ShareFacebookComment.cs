namespace App.Service.Facebook
{
    public class ShareFacebookComment
    {
        public string Comment { get; set; }
        public ShareFacebookComment(string comment)
        {
            this.Comment = comment;
        }
    }
}