namespace App.Api.Controllers
{
    using Common.DI;
    using Common.Http;
    using Common.Validation;
    using App.Service.Message;
    using System.Net;
    using System.Web.Http;

    [RoutePrefix("api/messages")]
    public class MessagesController : ApiController
    {
        [Route("")]
        [HttpPost()]
        public IResponseData<PostMessageResponse> Post(PostMessageRequest request)
        {
            IResponseData<PostMessageResponse> response = new ResponseData<PostMessageResponse>();
            try
            {
                IMessageService service = IoC.Container.Resolve<IMessageService>();
                PostMessageResponse postResult = service.Post(request);
                response.SetData(postResult);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(HttpStatusCode.PreconditionFailed);
            }
            return response;
        }

    }
}
