namespace App.Service.Impl.Message
{
    using App.Service.Message;
    using App.Common.Validation;
    using Common;
    using Common.Connector;

    internal class MessageService : IMessageService
    {
        public PostMessageResponse Post(PostMessageRequest request)
        {
            this.ValidatePostMessageRequest(request);
            IConnector facebookConnector = ConnectorFactory.Create(ConnectorType.Facebook);
            return facebookConnector.Post<PostMessageRequest, PostMessageResponse>(string.Empty, request).Data;
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
