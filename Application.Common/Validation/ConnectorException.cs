namespace App.Common.Validation
{
    using System;
    using System.Net.Http;

    public class ConnectorException : Exception
    {
        public HttpResponseMessage ResponseMessage { get; set; }
        public ConnectorException(HttpResponseMessage message) : base()
        {
            this.ResponseMessage = message;
        }
    }
}
