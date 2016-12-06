namespace App.Common.Connector
{
    using App.Common.Http;
    using System.Net.Http;
    using App.Common.Configurations;

    public class RESTConnector : BaseConnector, IConnector
    {
        public override IResponseData<TRespone> Put<TRequest, TRespone>(string uri, TRequest data)
        {
            using (HttpClient client = this.CreateHttpClient(Configuration.Current.IntegrationTest.BaseUrl))
            {
                HttpContent content = new JsonContent<TRequest>(data);
                HttpResponseMessage responseMessage = client.PutAsync(uri, content).Result;
                IResponseData<TRespone> result = this.GetResponseAs<ResponseData<TRespone>>(responseMessage.Content);
                return result;
            }
        }

        public override IResponseData<TResponse> Post<TRequest, TResponse>(string uri, TRequest data)
        {
            using (HttpClient client = this.CreateHttpClient(Configuration.Current.IntegrationTest.BaseUrl))
            {
                HttpContent content = new JsonContent<TRequest>(data);
                HttpResponseMessage responseMessage = client.PostAsync(uri, content).Result;
                IResponseData<TResponse> result = this.GetResponseAs<ResponseData<TResponse>>(responseMessage.Content);
                return result;
            }
        }

        public override IResponseData<TResponse> Delete<TResponse>(string uri)
        {
            using (HttpClient client = this.CreateHttpClient(Configuration.Current.IntegrationTest.BaseUrl))
            {
                HttpResponseMessage responseMessage = client.DeleteAsync(uri).Result;
                IResponseData<TResponse> result = this.GetResponseAs<ResponseData<TResponse>>(responseMessage.Content);
                return result;
            }
        }

        public override IResponseData<TResponse> Get<TResponse>(string uri)
        {
            using (HttpClient client = this.CreateHttpClient(Configuration.Current.IntegrationTest.BaseUrl))
            {
                HttpResponseMessage responseMessage = client.GetAsync(uri).Result;
                IResponseData<TResponse> result = this.GetResponseAs<ResponseData<TResponse>>(responseMessage.Content);
                return result;
            }
        }
    }
}
