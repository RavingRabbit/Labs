using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab3.FileLocking.Communication.Tests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void IsServerStartedTest()
        {
            Assert.IsFalse(Client.IsServerStarted());
            using (var server = new Server(msg => null))
            {
                server.Start();
                Assert.IsTrue(Client.IsServerStarted());
            }
            Assert.IsFalse(Client.IsServerStarted());
        }
    }
}