namespace App.Common.Connector
{
    using System;
    using App.Common.Http;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.IO;
    using Logging;
    using DI;

    public class BaseConnector : IConnector
    {
        public virtual IResponseData<TResponse> Delete<TResponse>(string uri)
        {
            throw new NotImplementedException();
        }

        public virtual IResponseData<TResponse> Get<TResponse>(string uri)
        {
            throw new NotImplementedException();
        }

        public virtual IResponseData<TResponse> Post<TRequest, TResponse>(string uri, TRequest data)
        {
            throw new NotImplementedException();
        }

        public virtual IResponseData<TResponse> Put<TRequest, TResponse>(string uri, TRequest data)
        {
            throw new NotImplementedException();
        }

        protected virtual HttpClient CreateHttpClient(string baseUrl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        protected TResponse GetResponseAs<TResponse>(HttpContent content)
        {
            string result = content.ReadAsStringAsync().Result;
            ILogger logger = IoC.Container.Resolve<ILogger>();
            logger.Info(result);
            return default(TResponse);
            //TResponse result = content.ReadAsAsync<TResponse>().Result;
            //return result;
        }
    }
}
