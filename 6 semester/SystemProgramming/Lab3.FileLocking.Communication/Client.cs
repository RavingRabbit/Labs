using System;
using System.Configuration;
using System.Net.Sockets;
using System.Threading.Tasks;
using Lab3.FileLocking.Communication.Config;
using RavingDev.Common;

namespace Lab3.FileLocking.Communication
{
    public sealed class Client
    {
        private static readonly String Hostname;
        private static readonly Int32 Port;

        private readonly MessageFormatter _messageFormatter;

        static Client()
        {
            var configuration = (ConfigHandler) ConfigurationManager.GetSection(ConfigHandler.SectionName);
            Hostname = configuration.Hostname;
            Port = configuration.Port;
        }

        public Client()
        {
            _messageFormatter = new MessageFormatter();
        }

        public static Boolean IsServerStarted()
        {
            Boolean isStarted;
            try
            {
                using (var tcpClient = new TcpClient(Hostname, Port))
                {
                    tcpClient.Close();
                }
                isStarted = true;
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == SocketError.ConnectionRefused)
                {
                    isStarted = false;
                }
                else
                {
                    throw;
                }
            }
            return isStarted;
        }

        public async Task<ResponseMessage> SendMessageAsync(RequestMessage message)
        {
            Requires.NotNull(message, "message");

            using (var tcpClient = new TcpClient(Hostname, Port))
            {
                NetworkStream stream = tcpClient.GetStream();
                await _messageFormatter.WriteMessageAsync(stream, message);
                ResponseMessage responseMessage = await _messageFormatter.ReadMessageAsync<ResponseMessage>(stream);
                return responseMessage;
            }
        }
    }
}