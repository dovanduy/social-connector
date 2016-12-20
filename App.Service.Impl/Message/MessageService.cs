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

    internal class MessageService : IMessageService
    {
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
                ////ShareComment shareComment = new ShareComment(request.Content);
                ////ILinkedInService linkedInService = IoC.Container.Resolve<ILinkedInService>();
                ////linkedInService.ShareComment(shareComment);

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
