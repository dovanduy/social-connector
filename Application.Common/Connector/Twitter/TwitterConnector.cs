namespace App.Common.Connector.Twitter
{
    using App.Common.Configurations;
    using App.Common.DI;
    using App.Common.Http;
    using System.Net.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    internal class TwitterConnector : BaseConnector
    {
        private const string AppConsumerKey = "9iDwZY1pRSNozUHHJ4nG3ylni";
        private const string AppConsumerSecret = "A8uDyUQHBNrxAMYW13FbOO7i52bSZNkMTOY8TSLSFqghDpe5vh";
        private const string AccessToken = " 806037750881226752-oqtUgPlIAs3RLFVEmdMprbzXlF4xGLJ";
        private const string AccessTokenSecret = "Girhom6ihod6N80RNmPKM2QLMr6qRTfvvdavHmgL4ac1j";
        private readonly DateTime EpochUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly HMACSHA1 sigHasher;

        public TwitterConnector()
        {
            this.sigHasher = new HMACSHA1(new ASCIIEncoding().GetBytes(string.Format("{0}&{1}", TwitterConnector.AppConsumerSecret, TwitterConnector.AccessTokenSecret)));
        }

        public override IResponseData<TResponse> Post<TRequest, TResponse>(string uri, TRequest data)
        {
            IConnectorBuilderFactory builderFactory = IoC.Container.Resolve<IConnectorBuilderFactory>();
            IRequestBuilder requestBuilder = builderFactory.Create(BuilderFactoryType.Twitter);
            OAuthRequest request = requestBuilder.GetOAuthRequest(data);

            using (HttpClient client = this.CreateHttpClient(Configuration.Current.Twitter.BaseApiUrl, request))
            {
                HttpContent content = new JsonContent<TRequest>(data);
                HttpResponseMessage responseMessage = client.PostAsync(request.Url, content).Result;
                IResponseData<TResponse> result = this.GetResponseAs<ResponseData<TResponse>>(responseMessage.Content);
                return result;
            }
        }

        protected HttpClient CreateHttpClient(string baseUrl, OAuthRequest request)
        {
            string authHeader = this.GetAuthHeader(request);
            HttpClient client = base.CreateHttpClient(baseUrl);
            client.DefaultRequestHeaders.Add("Authorization", authHeader);
            return client;
        }

        private string GetAuthHeader(OAuthRequest request)
        {
            var timestamp = (int)((DateTime.UtcNow - this.EpochUtc).TotalSeconds);
            request.Data.Add("oauth_consumer_key", TwitterConnector.AppConsumerKey);
            request.Data.Add("oauth_signature_method", "HMAC-SHA1");
            request.Data.Add("oauth_timestamp", timestamp.ToString());
            request.Data.Add("oauth_nonce", "a");
            request.Data.Add("oauth_token", TwitterConnector.AccessToken);
            request.Data.Add("oauth_version", "1.0");
            request.Data.Add("oauth_signature", this.GenerateSignature(request));
            return this.GenerateOAuthHeader(request.Data);
        }

        private string GenerateOAuthHeader(Dictionary<string, string> data)
        {
            return "OAuth " + string.Join(", ",
                data.Where(kvp => kvp.Key.StartsWith("oauth_"))
                .Select(kvp => string.Format("{0}=\"{1}\"", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))
                .OrderBy(s => s)
            );
        }

        private string GenerateSignature(OAuthRequest request)
        {
            string fullUrl = string.Format("{0}/{1}", App.Common.Configurations.Configuration.Current.Twitter.BaseApiUrl, request.Url);

            var sigString = string.Join("&", request.Data
                .Union(request.Data)
                .Select(kvp => string.Format("{0}={1}", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))
                .OrderBy(s => s)
            );

            var fullSigData = string.Format(
                "{0}&{1}&{2}",
                "POST",
                Uri.EscapeDataString(fullUrl),
                Uri.EscapeDataString(sigString.ToString())
            );

            return Convert.ToBase64String(this.sigHasher.ComputeHash(new ASCIIEncoding().GetBytes(fullSigData.ToString())));
        }
    }
}