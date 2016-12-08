namespace App.Service.Connector
{
    using App.Common.Connector;
    using System.Collections.Generic;

    internal class TwitterRequestBuilder : BaseRequestBuilder, IRequestBuilder
    {
        public override string CreateUrl<TData>(TData data)
        {
            if (typeof(IPostMessage).IsAssignableFrom(data.GetType()))
            {
                return this.CreateUrl((IPostMessage)data);
            }

            return string.Empty;
        }

        private string CreateUrl(IPostMessage data)
        {
            return string.Format("{0}{1}", App.Common.Configurations.Configuration.Current.Twitter.BaseApiUrl, "statuses/update.json");
            //return string.Format("{0}{1}", App.Common.Configurations.Configuration.Current.Twitter.BaseApiUrl, "account/verify_credentials.json");
        }

        public override OAuthRequest GetOAuthRequest<TRequest>(TRequest data)
        {
            if (typeof(IPostMessage).IsAssignableFrom(data.GetType()))
            {
                return this.GetOAuthRequest((IPostMessage)data);
            }

            throw new System.InvalidOperationException("This type of request was not supported by TwitterRequestBuilder");
        }

        private OAuthRequest GetOAuthRequest(IPostMessage message)
        {
            var data = new Dictionary<string, string> {
                { "status", message.Content },
                { "trim_user", "1" },
                //{ "include_entities", "true" }
            };

            return new OAuthRequest(this.CreateUrl(message), data);
        }
    }
}
