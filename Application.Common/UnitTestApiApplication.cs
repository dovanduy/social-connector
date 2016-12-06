namespace App.Common
{
    public class UnitTestApplication<TContext> : BaseApplication<TContext>
    {
        public UnitTestApplication(TContext context) : base(context, ApplicationType.Console)
        {
        }
    }
}