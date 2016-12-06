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
    }
}
