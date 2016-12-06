namespace App.Common.Connector
{
    public interface IPostMessage
    {
        string Subject { get; }
        string Content { get; }
    }
}
