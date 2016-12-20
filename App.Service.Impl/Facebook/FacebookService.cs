namespace App.Service.Impl.Facebook
{
    using App.Service.Facebook;
    using App.Common.Configurations;
    using App.Common.Connector;
    using App.Common;
    using Common.Helpers;
    using Service.Message;
    using System;
    using System.Collections.Generic;
    using Common.Http;

    internal class FacebookService : IFacebookService
    {
        public IList<MessageListItem> GetComments()
        {
            string url = string.Format(
                @"{0}/v2.8/me/feed?access_token={1}",
                Configuration.Current.Facebook.BaseApiUrl,
                Configuration.Current.Facebook.AccessToken);
            IConnector connector = ConnectorFactory.Create(ConnectorType.Facebook);
            IResponseData<IList<MessageListItem>> items = connector.Get<IList<MessageListItem>>(url);
            return items.Data;
        }

        public void ShareComment(ShareFacebookComment comment)
        {
            string url = string.Format(
                @"{0}/v2.8/me/feed?access_token={1}&message={2}",
                Configuration.Current.Facebook.BaseApiUrl,
                Configuration.Current.Facebook.AccessToken,
                UrlHelper.Encode(comment.Comment));
            IConnector connector = ConnectorFactory.Create(ConnectorType.Facebook);
            connector.Post<ShareFacebookComment, string>(url, comment);
        }
    }
}
