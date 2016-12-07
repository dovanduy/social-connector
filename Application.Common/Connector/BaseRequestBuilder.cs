namespace App.Common.Connector
{
    using System;

    public class BaseRequestBuilder : IRequestBuilder
    {
        public virtual string CreateUrl<TRequest>(TRequest data)
        {
            throw new NotImplementedException();
        }

        public virtual OAuthRequest GetOAuthRequest<TRequest>(TRequest data)
        {
            throw new NotImplementedException();
        }
    }
}
