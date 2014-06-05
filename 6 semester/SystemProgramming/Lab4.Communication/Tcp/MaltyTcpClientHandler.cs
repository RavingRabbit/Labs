using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using RavingDev.Communication.Tcp;

namespace Lab4.Communication.Tcp
{
    public sealed class MaltyTcpClientHandler<T> : TcpClientHandler<T>
    {
        private readonly object _handlersCollectionLocker = new object();
        private readonly List<HandlerRegistrationToken> _registeredHandlers = new List<HandlerRegistrationToken>();


        public MaltyTcpClientHandler(ITcpMsgFormatter<T> tcpMsgFormatter, ITcpMessageHandler<T> defaultTcpMessageHandler)
            : base(tcpMsgFormatter, defaultTcpMessageHandler)
        {
        }


        public void RegisterHandler(ITcpMessageHandler<T> handler, TimeSpan timeout, Predicate<T> requestPredicate)
        {
            var registrationToken = new HandlerRegistrationToken(handler, timeout, requestPredicate);
            lock (_handlersCollectionLocker)
            {
                _registeredHandlers.Add(registrationToken);
            }
        }

        protected override void HandleTcpMsg(T request, IPEndPoint remoteEndPoint, out T response)
        {
            T defaultHandlerResponse;
            base.HandleTcpMsg(request, remoteEndPoint, out defaultHandlerResponse);

            IEnumerable<ITcpMessageHandler<T>> handlers = GetHandlers(request);
            T additionalHandlerResponse = default(T);
            foreach (ITcpMessageHandler<T> handler in handlers)
            {
                handler.Handle(request, remoteEndPoint, out additionalHandlerResponse);
            }
            response = ReferenceEquals(defaultHandlerResponse, additionalHandlerResponse)
                ? defaultHandlerResponse
                : additionalHandlerResponse;
        }

        private IEnumerable<ITcpMessageHandler<T>> GetHandlers(T msg)
        {
            lock (_handlersCollectionLocker)
            {
                RemoveExpiredHandlers();
                return _registeredHandlers.Where(token => token.CanHandle(msg)).Select(token => token.Handler).ToList();
            }
        }

        private void RemoveExpiredHandlers()
        {
            List<HandlerRegistrationToken> expiredTokens = _registeredHandlers.Where(token => token.IsExpired).ToList();
            foreach (HandlerRegistrationToken expiredHandler in expiredTokens)
            {
                _registeredHandlers.Remove(expiredHandler);
            }
        }

        private struct HandlerRegistrationToken
        {
            private readonly DateTime _expired;
            private readonly ITcpMessageHandler<T> _handler;
            private readonly Predicate<T> _msgPredicate;

            public HandlerRegistrationToken(ITcpMessageHandler<T> handler, TimeSpan timeout, Predicate<T> msgPredicate)
            {
                _handler = handler;
                _msgPredicate = msgPredicate;
                _expired = DateTime.UtcNow + timeout;
            }

            public ITcpMessageHandler<T> Handler
            {
                get { return _handler; }
            }

            public bool IsExpired
            {
                get { return _expired < DateTime.UtcNow; }
            }

            public bool CanHandle(T request)
            {
                return _msgPredicate == null || _msgPredicate(request);
            }
        }
    }
}