namespace App.Common.Configurations
{
    using System.Configuration;

    public class TwitterElement : ConfigurationElement
    {
        [ConfigurationProperty("baseApiUrl")]
        public string BaseApiUrl
        {
            get { return (string)this["baseApiUrl"]; }
        }

        [ConfigurationProperty("consumerKey")]
        public string ConsumerKey
        {
            get { return (string)this["consumerKey"]; }
        }

        [ConfigurationProperty("consumerSecret")]
        public string ConsumerSecret
        {
            get { return (string)this["consumerSecret"]; }
        }

        [ConfigurationProperty("accessToken")]
        public string AccessToken
        {
            get { return (string)this["accessToken"]; }
        }

        [ConfigurationProperty("accessTokenSecret")]
        public string AccessTokenSecret
        {
            get { return (string)this["accessTokenSecret"]; }
        }
    }
}
