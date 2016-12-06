namespace App.Common.Connector.Facebook
{
    using App.Common.Http;
    using System.Net.Http;
    using App.Common.Configurations;
    using DI;

    internal class FacebookConnector : BaseConnector, IConnector
    {
        public override IResponseData<TResponse> Post<TRequest, TResponse>(string uri, TRequest data)
        {
            IConnectorBuilderFactory builderFactory = IoC.Container.Resolve<IConnectorBuilderFactory>();
            IRequestBuilder requestBuilder = builderFactory.Create(BuilderFactoryType.Facebook);

            string url = requestBuilder.CreateUrl(data);
            using (HttpClient client = this.CreateHttpClient(Configuration.Current.Facebook.BaseApiUrl))
            {
                HttpContent content = new JsonContent<TRequest>(data);
                HttpResponseMessage responseMessage = client.PostAsync(url, content).Result;
                IResponseData<TResponse> result = this.GetResponseAs<ResponseData<TResponse>>(responseMessage.Content);
                return result;
            }
        }
    }
}
