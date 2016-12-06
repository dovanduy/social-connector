using App.Common.Configurations;
using App.Common.DI;
using App.Common.Http;
using System.Net.Http;
using System;

namespace App.Common.Connector.Twitter
{
    internal class TwitterConnector : BaseConnector 
    {
        private const string AppConsumerKey = "9iDwZY1pRSNozUHHJ4nG3ylni";
        private const string AppConsumerSecret = "A8uDyUQHBNrxAMYW13FbOO7i52bSZNkMTOY8TSLSFqghDpe5vh";
        private const string AccessToken = " 806037750881226752-oqtUgPlIAs3RLFVEmdMprbzXlF4xGLJ";
        private const string AccessTokenSecret = "Girhom6ihod6N80RNmPKM2QLMr6qRTfvvdavHmgL4ac1j";

        public override IResponseData<TResponse> Post<TRequest, TResponse>(string uri, TRequest data)
        {
            IConnectorBuilderFactory builderFactory = IoC.Container.Resolve<IConnectorBuilderFactory>();
            IRequestBuilder requestBuilder = builderFactory.Create(BuilderFactoryType.Twitter);
            string url = requestBuilder.CreateUrl(data);

            using (HttpClient client = this.CreateHttpClient(Configuration.Current.Twitter.BaseApiUrl))
            {
                HttpContent content = new JsonContent<TRequest>(data);
                HttpResponseMessage responseMessage = client.PostAsync(url, content).Result;
                IResponseData<TResponse> result = this.GetResponseAs<ResponseData<TResponse>>(responseMessage.Content);
                return result;
            }
        }
        protected override HttpClient CreateHttpClient(string baseUrl)
        {
            string authHeader = this.GetAuthHeader();
            HttpClient client = base.CreateHttpClient(baseUrl);
            client.DefaultRequestHeaders.Add("Authorization", authHeader);
            return client;
        }

        private string GetAuthHeader()
        {
            throw new NotImplementedException();
        }
    }
}
