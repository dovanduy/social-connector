namespace App.Common.Connector.Facebook
{
    using App.Common.Configurations;

    internal class FacebookRequestBuilder
    {
        internal static string CreateUrl<TRequest>(TRequest data)
        {
            string accessToken = "EAAFUS06xm00BAFyUnZAvCyc3HBnGnwR26zMwmqVteiyPHFk6ZCLTiE8nKHWFwokOJQZBZBB2ySZCSdxoj1ZBRnsu0UmLEPUAUN72l2TyjgsY1rwh5zuZBYrZBe9TQcuP6p3YgrBiNfKBSEZAwROadzow6XuLjuis8IVzK2hETGYeBAAZDZD";
            return string.Format(@"{0}/v2.8/me/feed?access_token={1}&message=test content", Configuration.Current.Facebook.BaseApiUrl, accessToken);
        }
    }
}
