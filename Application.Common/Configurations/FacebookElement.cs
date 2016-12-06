namespace App.Common.Configurations
{
    using System.Configuration;

    public class FacebookElement : ConfigurationElement
    {
        [ConfigurationProperty("baseApiUrl")]
        public string BaseApiUrl
        {
            get { return (string)this["baseApiUrl"]; }
        }
    }
}
