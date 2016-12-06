namespace App.Common.Connector
{
    using App.Common.Connector.Facebook;

    public interface IConnectorBuilderFactory
    {
        IRequestBuilder Create(BuilderFactoryType builderFactoryType);
    }
}
