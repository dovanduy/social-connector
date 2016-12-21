namespace App.Service.Impl.LinkedIn
{
    using App.Service.LinkedIn;
    using App.Common.Connector;
    using App.Common;
    using Common.Helpers;

    internal class LinkedInService : ILinkedInService
    {
        public ShareCommentResponse ShareComment(ShareLinkedInComment shareComment)
        {
            string url = string.Format("{0}{1}", App.Common.Configurations.Configuration.Current.LinkedIn.BaseApiUrl, "people/~/shares");
            url = UrlHelper.Append(url, "oauth2_access_token", App.Common.Configurations.Configuration.Current.LinkedIn.AccessToken);

            IConnector connector = ConnectorFactory.Create(ConnectorType.LinkedIn);
            connector.Post<ShareLinkedInComment, ShareCommentResponse>(url, shareComment);
            return new ShareCommentResponse();
        }
    }
}
