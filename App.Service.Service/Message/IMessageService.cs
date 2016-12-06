namespace App.Service.Message
{
    public interface IMessageService
    {
        PostMessageResponse Post(PostMessageRequest request);
    }
}
