namespace App.Common
{
    using App.Common.DI;
    using App.Common.Logging;
    using App.Common.Tasks;

    public class Bootstrap : BaseTask<IBaseContainer>, IBootstrapper
    {
        public Bootstrap() : base(ApplicationType.All)
        {
        }

        public override void Execute(IBaseContainer context)
        {
            context.RegisterSingleton<ILogger, DefaultLogger>();
            context.RegisterSingleton<App.Common.Mail.IMailService, App.Common.Mail.MailService>();
            context.RegisterSingleton<App.Common.Event.IEventManager, App.Common.Event.BaseEventManager>();
        }
    }
}