namespace App.Common.Connector
{
    using App.Common.Connector.Facebook;

    public interface IConnectorBuilderFactory
    {
        IFacebookRequestBuilder Create(BuilderFactoryType builderFactoryType);
    }
}
