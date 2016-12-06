namespace App.Service.Connector
{
    using App.Common.Connector;

    internal class TwitterRequestBuilder : IRequestBuilder
    {
        public string CreateUrl<TData>(TData data)
        {
            if (typeof(IPostMessage).IsAssignableFrom(data.GetType()))
            {
                return this.CreateUrl((IPostMessage)data);
            }

            return string.Empty;
        }

        private string CreateUrl(IPostMessage data)
        {
            return string.Format("{0}/{1}", App.Common.Configurations.Configuration.Current.Twitter.BaseApiUrl, "statuses/update.json");
        }
    }
}
