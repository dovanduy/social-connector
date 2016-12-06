namespace App.Service.Impl.Connector
{
    using App.Common.Connector.Facebook;
    using Common.Configurations;

    internal class FacebookRequestBuilder : IFacebookRequestBuilder
    {
        public string CreateUrl<TData>(TData data)
        {
            if (typeof(IFacebookPostMessage).IsAssignableFrom(data.GetType()))
            {
                return this.CreateUrl((IFacebookPostMessage)data);
            }

            return string.Empty;
        }

        private string CreateUrl(IFacebookPostMessage data)
        {
            string accessToken = "EAAFUS06xm00BAFyUnZAvCyc3HBnGnwR26zMwmqVteiyPHFk6ZCLTiE8nKHWFwokOJQZBZBB2ySZCSdxoj1ZBRnsu0UmLEPUAUN72l2TyjgsY1rwh5zuZBYrZBe9TQcuP6p3YgrBiNfKBSEZAwROadzow6XuLjuis8IVzK2hETGYeBAAZDZD";
            return string.Format(@"{0}/v2.8/me/feed?access_token={1}&message={2}", Configuration.Current.Facebook.BaseApiUrl, accessToken, data.Content);
        }
    }
}
