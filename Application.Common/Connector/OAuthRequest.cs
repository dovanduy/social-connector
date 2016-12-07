namespace App.Common.Connector
{
    using System.Collections.Generic;

    public class OAuthRequest
    {
        public string Url { get; protected set; }
        public Dictionary<string, string> Data { get; protected set; }

        public OAuthRequest(string url, Dictionary<string, string> data)
        {
            this.Url = url;
            this.Data = data;
        }
    }
}