namespace App.Test.Message
{
    using App.Common.DI;
    using App.Common.UnitTest;
    using App.Service.Message;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class MessageService : BaseUnitTest
    {
        [TestMethod]
        public void TwitterConnector_CanPostMessage_ToUserTwitterAccount()
        {
            try
            {
                PostMessageRequest request = new PostMessageRequest() { Content = string.Format("Just test my API Content:{0}", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")) };
                IMessageService service = IoC.Container.Resolve<IMessageService>();
                PostMessageResponse postResult = service.Post(request);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TwitterConnector_CanGetMessages()
        {
            try
            {
                IMessageService service = IoC.Container.Resolve<IMessageService>();
                IList<MessageListItem> items = service.GetMessages();
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }
    }
}
