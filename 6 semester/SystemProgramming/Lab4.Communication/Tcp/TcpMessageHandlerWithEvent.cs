using System.Net;
using System.Threading;
using RavingDev.Communication.Tcp;

namespace Lab4.Communication.Tcp
{
    public sealed class TcpMessageHandlerWithEvent<T> : ITcpMessageHandler<T>
    {
        private readonly ITcpMessageHandler<T> _tcpMessageHandler;
        private readonly EventWaitHandle _waitHandle;

        public TcpMessageHandlerWithEvent(ITcpMessageHandler<T> tcpMessageHandler, EventWaitHandle waitHandle)
        {
            _tcpMessageHandler = tcpMessageHandler;
            _waitHandle = waitHandle;
        }

        public void Handle(T msg, IPEndPoint remoteEndPoint, out T response)
        {
            _tcpMessageHandler.Handle(msg, remoteEndPoint, out response);
            _waitHandle.Set();
        }
    }
}