namespace App.Service.LinkedIn
{
    using App.Common;

    public class ShareComment
    {
        public string Comment { get; set; }
        public LinkedVisibility Visibility { get; set; }
        public ShareComment(string comment)
        {
            this.Comment = comment;
            this.Visibility = new LinkedVisibility(VisibilityType.AnyOne);
        }
    }
}