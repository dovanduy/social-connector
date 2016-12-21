using System.Collections.Generic;
using App.Service.Message;

namespace App.Service.Facebook
{
    public interface IFacebookService
    {
        void ShareComment(ShareFacebookComment comment);
        IList<MessageListItem> GetComments();
        void CommentOnFeed(FacebookCommentOnFeed shareFBComment);
    }
}
