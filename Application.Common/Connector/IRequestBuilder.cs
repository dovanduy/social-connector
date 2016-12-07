namespace App.Common.Connector
{
    public interface IRequestBuilder
    {
        string CreateUrl<TRequest>(TRequest data);
        OAuthRequest GetOAuthRequest<TRequest>(TRequest data);
    }
}
