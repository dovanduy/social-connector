namespace App.Service.Impl.Connector
{
    using Common.Configurations;
    using Common.Connector;

    internal class FacebookRequestBuilder : BaseRequestBuilder, IRequestBuilder
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
            string accessToken = "EAAFUS06xm00BAH8PIIOpk6bq80hGRRAYMTYa8Jfq7k88cSVI4k2Y0ERBYf4a5NsVZBejXAZCCnkFv7fChXMziHFISAyn6AHXq9zy9tgseVEfmrqvlJOxZAVF50sZCJ3NcoyscmBxdjbdmkZCYvicRDBbD9kRRL8EQyzFZC57cZBMwZDZD";
            return string.Format(@"{0}/v2.8/me/feed?access_token={1}&message={2}", Configuration.Current.Facebook.BaseApiUrl, accessToken, data.Content);
        }
    }
}
