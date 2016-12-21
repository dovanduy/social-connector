namespace App.Service.LinkedIn
{
    using App.Common;

    public class ShareLinkedInComment
    {
        public string Comment { get; set; }
        public LinkedVisibility Visibility { get; set; }
        public ShareLinkedInComment(string comment)
        {
            this.Comment = comment;
            this.Visibility = new LinkedVisibility(VisibilityType.AnyOne);
        }
    }
}