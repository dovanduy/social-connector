namespace App.Service.Impl.Message
{
    using App.Service.Message;
    using App.Common.Validation;
    using Common.DI;
    using Service.Twitter;
    using Service.Facebook;

    internal class MessageService : IMessageService
    {
        public PostMessageResponse Post(PostMessageRequest request)
        {
            this.ValidatePostMessageRequest(request);

            ShareFacebookComment shareFBComment = new ShareFacebookComment(request.Content);
            IFacebookService facebookInService = IoC.Container.Resolve<IFacebookService>();
            facebookInService.ShareComment(shareFBComment);

            //// was eexceed of limitation
            ////ShareComment shareComment = new ShareComment(request.Content);
            ////ILinkedInService linkedInService = IoC.Container.Resolve<ILinkedInService>();
            ////linkedInService.ShareComment(shareComment);

            ShareTwitterComment twitterComment = new ShareTwitterComment(request.Content);
            ITwitterService twitterService = IoC.Container.Resolve<ITwitterService>();
            twitterService.ShareComment(twitterComment);
            return new PostMessageResponse();
        }

        private void ValidatePostMessageRequest(PostMessageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Subject))
            {
                throw new ValidationException("message.post.subjectIsRequires");
            }

            if (string.IsNullOrWhiteSpace(request.Content))
            {
                throw new ValidationException("message.post.contentIsRequires");
            }
        }
    }
}
