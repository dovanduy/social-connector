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
            context.RegisterSingleton<App.Service.LinkedIn.ILinkedInService, App.Service.Impl.LinkedIn.LinkedInService>();
            context.RegisterSingleton<App.Service.Twitter.ITwitterService, App.Service.Impl.Twitter.TwitterService>();
            context.RegisterSingleton<App.Service.Facebook.IFacebookService, App.Service.Impl.Facebook.FacebookService>();
        }
    }
}