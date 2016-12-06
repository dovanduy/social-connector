namespace App.Common
{
    using App.Common.Validation;

    public class ApplicationFactory
    {
        public static IApplication Create<TContext>(ApplicationType type, TContext application)
        {
            switch (type)
            {
                case ApplicationType.Console:
                    return new ConsoleApplication<TContext>(application);
                case ApplicationType.MVC:
                    return new MVCApplication<TContext>(application);
                case ApplicationType.WebApi:
                    return new WebApiApplication(application as System.Web.HttpApplication);
                case ApplicationType.UnitTest:
                    return new UnitTestApplication<TContext>(application);
                default:
                    throw new ValidationException("Common.ApplicationDoesNotSupported", type);
            }
        }
    }
}