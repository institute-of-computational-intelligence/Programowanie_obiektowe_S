using AutoMapper;
using Lab12.Server.DAL;
using Lab12.Server.Model.Entities;
using Lab12.Server.Utilities.Utils;
using Lab12.Server.Utilities.VMs;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab12.Server
{
    public class ServerListener : IDisposable, IServerListener
    {
        private readonly object _lockObject = new object();
        private readonly IMapper _mapper;
        private readonly Socket _socket;
        private ISessionFactory _sessionFactory;
        private bool IsServerRunning { get; set; }

        public ServerListener(IMapper mapper)
        {
            _mapper = mapper;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IsServerRunning = true;
        }

        private ISessionFactory SessionFactory
        {
            get
            {
                lock(_lockObject)
                {
                    return _sessionFactory ?? (_sessionFactory = SessionFactoryBuilder
                        .BuildSessionFactory(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString));

                }
            }
        }

        public void StopServer()
        {
            IsServerRunning = false;
        }

        public void StartServer()
        {
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, 9999);
                _socket.Bind(ip);
                _socket.Listen(10);
                Console.WriteLine("Waiting for a client......");

                while (IsServerRunning)
                {
                    Socket client = _socket.Accept();
                    Task.Run(() =>
                    {
                        IPEndPoint clientEndPoint = (IPEndPoint)client.RemoteEndPoint;
                        Console.WriteLine($"Connected with client, address {clientEndPoint.Address}, port: {clientEndPoint.Port}");

                        using (var sesion = SessionFactory.OpenSession())
                        {
                            var messages = sesion
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
                        Console.WriteLine("Disconnected from client, addres: {0}", clientEndPoint.Address);
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                    });
                }
            } catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
            }
        }

        public void Dispose()
        {
            _socket.Close();
        }
    }
}
