namespace App.Common.Connector
{
    using App.Common.Connector.Facebook;
    using Twitter;

    public class ConnectorFactory
    {
        public static IConnector Create(ConnectorType type)
        {
            switch (type)
            {
                case ConnectorType.Twitter:
                    return new TwitterConnector();
                case ConnectorType.Facebook:
                    return new FacebookConnector();
                case ConnectorType.REST:
                default:
                    return new RESTConnector();
            }
        }
    }
}
