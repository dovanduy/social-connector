namespace App.Common.Connector.Facebook
{
    using App.Common.Http;
    using System.Net.Http;
    using App.Common.Configurations;
    using Helpers;

    internal class LinkedInConnector : BaseConnector, IConnector
    {
        public override IResponseData<TResponse> Post<TRequest, TResponse>(string uri, TRequest data)
        {
            using (HttpClient client = this.CreateHttpClient(Configuration.Current.LinkedIn.BaseApiUrl))
            {
                string text = JsonHelper.ToString(data);
                HttpContent content = new StringContent(text);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage responseMessage = client.PostAsync(uri, content).Result;

                this.ThrowIfErrorResponse(responseMessage);

                //// temprary
                ////IResponseData<TResponse> result = this.GetResponseAs<ResponseData<TResponse>>(responseMessage);

                return default(IResponseData<TResponse>);
            }
        }
    }
}
