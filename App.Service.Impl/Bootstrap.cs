namespace App.Service
{
    using App.Common;
    using App.Common.DI;
    using App.Common.Tasks;

    public class Bootstrap : BaseTask<IBaseContainer>, IBootstrapper
    {
        public Bootstrap() : base(ApplicationType.All)
        {
        }

        public override void Execute(IBaseContainer context)
        {
            context.RegisterSingleton<App.Service.Message.IMessageService, App.Service.Impl.Message.MessageService>();
            context.RegisterSingleton<App.Common.Connector.IConnectorBuilderFactory, App.Service.Impl.Connector.ConnectorBuilderFactory>();
        }
    }
}