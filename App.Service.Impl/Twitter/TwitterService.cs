namespace App.Service.Impl.Twitter
{
    using App.Service.Twitter;
    using Twitterizer;

    internal class TwitterService : ITwitterService
    {
        public void ShareComment(ShareTwitterComment comment)
        {
            OAuthTokens tokens = new OAuthTokens();
            tokens.ConsumerKey = App.Common.Configurations.Configuration.Current.Twitter.ConsumerKey;
            tokens.ConsumerSecret = App.Common.Configurations.Configuration.Current.Twitter.ConsumerSecret;
            tokens.AccessToken = App.Common.Configurations.Configuration.Current.Twitter.AccessToken;
            tokens.AccessTokenSecret = App.Common.Configurations.Configuration.Current.Twitter.AccessTokenSecret;
            TwitterStatus.Update(tokens, comment.Status);
        }
    }
}
