namespace App.Test.Message
{
    using App.Common.DI;
    using App.Common.UnitTest;
    using App.Service.Message;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MessageService : BaseUnitTest
    {
        [TestMethod]
        public void TwitterConnector_CanPostMessage_ToUserTwitterAccount()
        {
            PostMessageRequest request = new PostMessageRequest() { Subject = "Hello Ladies + Gentlemen, a signed OAuth request!", Content = "Hello Ladies + Gentlemen, a signed OAuth request!" };
            IMessageService service = IoC.Container.Resolve<IMessageService>();
            PostMessageResponse postResult = service.Post(request);
        }
    }
}
