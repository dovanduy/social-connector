namespace App.Service.Impl.Connector
{
    using App.Common.Connector;
    using App.Common.Connector.Facebook;
    using Common;

    internal class ConnectorBuilderFactory : IConnectorBuilderFactory
    {
        public IFacebookRequestBuilder Create(BuilderFactoryType builderType)
        {
            switch (builderType) {
                case BuilderFactoryType.Facebook:
                default:
                    return new FacebookRequestBuilder();
            }
        }
    }
}
