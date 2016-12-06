namespace App.Service.Impl.Connector
{
    using App.Common.Connector;
    using Common;
    using Service.Connector;

    internal class ConnectorBuilderFactory : IConnectorBuilderFactory
    {
        public IRequestBuilder Create(BuilderFactoryType builderType)
        {
            switch (builderType)
            {
                case BuilderFactoryType.Twitter:
                    return new TwitterRequestBuilder();
                case BuilderFactoryType.Facebook:
                default:
                    return new FacebookRequestBuilder();
            }
        }
    }
}
