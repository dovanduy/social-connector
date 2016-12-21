namespace App.Service.Impl.Message
{
    using App.Service.Message;
    using App.Common.Validation;
    using Common.DI;
    using Service.Twitter;
    using Service.Facebook;
    using System;
    using Common.Logging;
    using System.Collections.Generic;
    using Service.LinkedIn;

    internal class MessageService : IMessageService
    {
        public void CommentOnFeed(CommentOnFeedRequest request)
        {
            this.ValidateCommentOnFeedRequest(request);
            FacebookCommentOnFeed fbCommentOnFeed = new FacebookCommentOnFeed(request.Id, request.Comment);
            IFacebookService facebookInService = IoC.Container.Resolve<IFacebookService>();
            facebookInService.CommentOnFeed(fbCommentOnFeed);
        }

        private void ValidateCommentOnFeedRequest(CommentOnFeedRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Id)) {
                throw new ValidationException("message.commentOnFeed.objectIdIsRequired");
            }

            if (string.IsNullOrWhiteSpace(request.Comment))
            {
                throw new ValidationException("message.commentOnFeed.commentIsRequired");
            }
        }

        public IList<MessageListItem> GetMessages()
        {
            IFacebookService facebookInService = IoC.Container.Resolve<IFacebookService>();
            IList<MessageListItem> comments = facebookInService.GetComments();
            return comments;
        }

        public PostMessageResponse Post(PostMessageRequest request)
        {
            try
            {
                this.ValidatePostMessageRequest(request);
                ShareFacebookComment shareFBComment = new ShareFacebookComment(request.Content);
                IFacebookService facebookInService = IoC.Container.Resolve<IFacebookService>();
                facebookInService.ShareComment(shareFBComment);

                //// was eexceed of limitation
                ShareLinkedInComment shareLinkedInComment = new ShareLinkedInComment(request.Content);
                ILinkedInService linkedInService = IoC.Container.Resolve<ILinkedInService>();
                linkedInService.ShareComment(shareLinkedInComment);

                //ShareTwitterComment twitterComment = new ShareTwitterComment(request.Content);
                //ITwitterService twitterService = IoC.Container.Resolve<ITwitterService>();
                //twitterService.ShareComment(twitterComment);
            }
            catch (ConnectorException ex) {
                ILogger logger = IoC.Container.Resolve<ILogger>();
                logger.Error(ex.ResponseMessage);
            }

            return new PostMessageResponse();
        }

        private void ValidatePostMessageRequest(PostMessageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Content))
            {
                throw new ValidationException("message.post.contentIsRequires");
            }
        }
    }
}
