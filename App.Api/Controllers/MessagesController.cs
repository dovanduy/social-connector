namespace App.Api.Controllers
{
    using Common.DI;
    using Common.Http;
    using Common.Validation;
    using App.Service.Message;
    using System.Net;
    using System.Web.Http;
    using System.Collections.Generic;

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

        [Route("")]
        [HttpGet()]
        public IResponseData<IList<MessageListItem>> GetMessages()
        {
            IResponseData<IList<MessageListItem>> response = new ResponseData<IList<MessageListItem>>();
            try
            {
                IMessageService service = IoC.Container.Resolve<IMessageService>();
                IList<MessageListItem> items = service.GetMessages();
                response.SetData(items);
            }
            catch (ValidationException ex)
            {
                response.SetStatus(HttpStatusCode.PreconditionFailed);
                response.SetErrors(ex.Errors);
            }
            return response;
        }
    }
}
