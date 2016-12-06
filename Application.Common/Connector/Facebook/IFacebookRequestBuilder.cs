namespace App.Common.Connector.Facebook
{
    public interface IFacebookRequestBuilder
    {
        string CreateUrl<TRequest>(TRequest data);
    }
}
