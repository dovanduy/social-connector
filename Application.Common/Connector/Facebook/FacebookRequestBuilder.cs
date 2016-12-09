namespace App.Common.Connector.Facebook
{
    using App.Common.Configurations;

    internal class FacebookRequestBuilder
    {
        internal static string CreateUrl<TRequest>(TRequest data)
        {
            string accessToken = "EAAFUS06xm00BAAYJexgEfsHpWdroc88lThN5c7Uj2SgStQUA3lyikLe9uz7hh8g00ZAW9oegZBmD2fBMKXyIoclM54CapGxwvsT53Nq1yo5L6rFeoF12hOstZADt4xWpFOZAhG6aZAIp3P8Cj9YG9NniGqyZBVLmE86AIDtZBYxlwZDZD";
            return string.Format(@"{0}/v2.8/me/feed?access_token={1}&message=test content", Configuration.Current.Facebook.BaseApiUrl, accessToken);
        }
    }
}
