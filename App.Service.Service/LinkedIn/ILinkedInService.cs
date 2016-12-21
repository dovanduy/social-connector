namespace App.Service.LinkedIn
{
    public interface ILinkedInService
    {
        ShareCommentResponse ShareComment(ShareLinkedInComment shareComment);
    }
}
