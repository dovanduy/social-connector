namespace App.Service.Impl.Message
{
    using App.Service.Message;
    using App.Common.Validation;
    using Service.LinkedIn;
    using Common.DI;

    internal class MessageService : IMessageService
    {
        public PostMessageResponse Post(PostMessageRequest request)
        {
            this.ValidatePostMessageRequest(request);

            //// IConnector facebookConnector = ConnectorFactory.Create(ConnectorType.Facebook);
            //// facebookConnector.Post<PostMessageRequest, PostMessageResponse>(string.Empty, request);

            ShareComment shareComment = new ShareComment(request.Content);
            ILinkedInService linkedInService = IoC.Container.Resolve<ILinkedInService>();
            linkedInService.ShareComment(shareComment);

            /* To do*/
            //// IConnector linkedInConnector = ConnectorFactory.Create(ConnectorType.LinkedIn);
            //// linkedInConnector.Post<PostMessageRequest, PostMessageResponse>(string.Empty, request);

            ////IConnector twitterConnector = ConnectorFactory.Create(ConnectorType.Twitter);
            ////twitterConnector.Post<PostMessageRequest, PostMessageResponse>(string.Empty, request);

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
