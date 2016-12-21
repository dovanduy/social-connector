namespace Social.Controllers
{
    using App.Api.Models.Home;
    using App.Common.DI;
    using App.Service.Message;
    using System;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult PostMessage(string id, string message)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    this.PostNewFeed(message);
                }
                else
                {
                    this.CommentOnFeed(id, message);
                }

                return View(true);
            }
            catch (Exception ex)
            {
                return View(false);
            }
        }

        private void CommentOnFeed(string id, string message)
        {
            IMessageService messageService = IoC.Container.Resolve<IMessageService>();
            CommentOnFeedRequest request = new CommentOnFeedRequest(id, message);
            messageService.CommentOnFeed(request);
        }

        private void PostNewFeed(string message)
        {
            IMessageService messageService = IoC.Container.Resolve<IMessageService>();
            PostMessageRequest request = new PostMessageRequest(message);
            messageService.Post(request);
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            IMessageService messageService = IoC.Container.Resolve<IMessageService>();
            DashboardViewModel viewModel = new DashboardViewModel();
            viewModel.Messages = messageService.GetMessages();

            return View(viewModel);
        }
    }
}
