namespace App.Common.Authorize
{
    using System.Web.Http.Controllers;

    public interface IAuthorization
    {
        bool IsAuthorized(System.Web.HttpContextBase httpContext);
        bool IsAuthorized(string token);
    }
}
