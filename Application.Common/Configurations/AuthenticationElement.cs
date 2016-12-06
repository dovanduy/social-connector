namespace App.Common.Configurations
{
    using System.Configuration;

    public class AuthenticationElement : ConfigurationElement
    {
        [ConfigurationProperty("tokenExpiredAfterInMinute")]
        public double TokenExpiredAfterInMinute
        {
            get { return (double)this["tokenExpiredAfterInMinute"]; }
        }
    }
}
