namespace App.Service.Message
{
    public interface IMessageService
    {
        PostMessageResponse Post(PostMessageRequest request);
        System.Collections.Generic.IList<MessageListItem> GetMessages();
    }
}
