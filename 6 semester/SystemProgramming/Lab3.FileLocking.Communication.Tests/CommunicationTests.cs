using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab3.FileLocking.Communication.Tests
{
    [TestClass]
    public class CommunicationTests
    {
        private const String TestFileName = "33772D51-4C0D-407C-8ED1-F0CA5D7E8DE6";
        private static readonly Func<RequestMessage, ResponseMessage> MessageHandler;
        private static readonly ResponseMessage ExpectedResponseMessage;

        private readonly Server _server;

        static CommunicationTests()
        {
            ExpectedResponseMessage = ResponseMessage.CreateAccessGranted(TestFileName);
            MessageHandler = message => ExpectedResponseMessage;
        }

        public CommunicationTests()
        {
            _server = new Server(MessageHandler);
        }

        [TestInitialize]
        public void Startup()
        {
            _server.Start();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _server.Dispose();
        }

        [TestMethod]
        public void SendMessageAsyncTest()
        {
            var client = new Client();
            RequestMessage testMessage = RequestMessage.CreateAccessRequest(TestFileName);

            ResponseMessage responseMessage = client.SendMessageAsync(testMessage).Result;

            Assert.AreEqual(ExpectedResponseMessage, responseMessage);
        }
    }
}