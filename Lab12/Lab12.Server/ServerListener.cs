using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AutoMapper;
using Lab12.Server.DAL;
using Lab12.Server.Model.Entities;
using Lab12.Utilities.Utils;
using Lab12.Utilities.VMs;
using NHibernate;
using NHibernate.Transform;

namespace Lab12.Server
{
    public class ServerListener : IDisposable, IServerListener
    {
        private readonly object _lockObject = new object();
        private readonly IMapper _mapper;
        private ISessionFactory _sessionFactory;
        private readonly Socket _socket;
        public ServerListener(IMapper mapper)
        {
            _mapper = mapper;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IsServerRunning = true;
        }
        public bool IsServerRunning { get; set; }
        private ISessionFactory SessionFactory
        {
            get
            {
                lock (_lockObject)
                {
                    return _sessionFactory ?? (_sessionFactory = SessionFactoryBuilder
                               .BuildSessionFactory(ConfigurationManager
                                   .ConnectionStrings["DefaultConnectionString"].ConnectionString));
                }
            }
        }
        public void StopServer()
        {
            IsServerRunning = false;
        }
        public void Dispose()
        {
            _socket.Close();
        }
        public void StartServer()
        {
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, 9999);
                _socket.Bind(ip);
                _socket.Listen(10);
                Console.WriteLine("Waiting for a client...");
                while (IsServerRunning)
                {
                    Socket client = _socket.Accept();
                    Task.Run(() =>
                    {
                        IPEndPoint clientEndPoint = (IPEndPoint)client.RemoteEndPoint;
                        Console.WriteLine($"Connected with {clientEndPoint.Address} at port {clientEndPoint.Port}");
                        using (var session = SessionFactory.OpenSession())
                        {
                            var messages = session
                                .QueryOver<Message>()
                                .JoinQueryOver(m => m.Attachments)
                                .TransformUsing(Transformers.DistinctRootEntity)
                                .List();
                            var messageVms = _mapper.Map<IList<MessageVm>>(messages);
                            Console.WriteLine("Transmitting data......");
                            var messagesBytes = messageVms.Serialize();
                            client.Send(messagesBytes, messagesBytes.Length, SocketFlags.None);
                            var fileBytes = File.ReadAllBytes("./Attachments/Attachment1.bin");
                            client.Send(fileBytes, fileBytes.Length, SocketFlags.None);
                            fileBytes = File.ReadAllBytes("./Attachments/Attachment2.bin");
                            client.Send(fileBytes, fileBytes.Length, SocketFlags.None);
                        }
                        Console.WriteLine("Transmission done.");
                        Console.WriteLine("Disconnected from {0}", clientEndPoint.Address);
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
