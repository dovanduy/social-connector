namespace App.Common.Configurations
{
    using System.Configuration;

    public class LinkedInElement : ConfigurationElement
    {
        [ConfigurationProperty("baseApiUrl")]
        public string BaseApiUrl
        {
            get { return (string)this["baseApiUrl"]; }
        }

        [ConfigurationProperty("accessToken")]
        public string AccessToken
        {
            get
            {
                return (string)this["accessToken"];
            }
        }
    }
}
