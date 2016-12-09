namespace App.Common.Helpers
{
    using System.Web;

    public class UrlHelper
    {
        public static string Append(string url, string name, string value)
        {
            string param = string.Format("{0}={1}", name, UrlHelper.Encode(value));
            bool isQuestionMarkExistedInUrl = url.Contains("?");
            return string.Format("{0}{1}{2}", url, isQuestionMarkExistedInUrl ? "&" : "?", param);
        }

        public static string Encode(string value)
        {
            return HttpUtility.UrlEncode(value);
        }
    }
}
