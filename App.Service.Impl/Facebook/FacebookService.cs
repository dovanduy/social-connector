namespace App.Service.Impl.Facebook
{
    using App.Service.Facebook;
    using App.Common.Configurations;
    using App.Common.Connector;
    using App.Common;

    internal class FacebookService : IFacebookService
    {
        public void ShareComment(ShareFacebookComment comment)
        {
            string url = string.Format(
                @"{0}/v2.8/me/feed?access_token={1}&message={2}", 
                Configuration.Current.Facebook.BaseApiUrl,
                Configuration.Current.Facebook.AccessToken, 
                comment.Comment);
            IConnector connector = ConnectorFactory.Create(ConnectorType.Facebook);
            connector.Post<ShareFacebookComment, string>(url, comment);
        }
    }
}
