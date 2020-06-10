using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AutoMapper;//trzeba doinstalowac
using Lab12.Server.DAL;
using Lab12.Server.Model.Entities;
using Lab12.Server.Utilities.Utils;
using Lab12.Server.Utilities.VMs;
using NHibernate;
using NHibernate.Transform;

namespace Lab12.Server
{
    public class ServerListener : IDisposable, IServerListener
    {
        private readonly object lockObject = new object();
        private readonly IMapper mapper;
        private ISessionFactory sessionFactory;
        private readonly Socket socket;

        public bool IsServerRunning { get; set; }

        public ServerListener(IMapper mapper)
        {
            this.mapper = mapper;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IsServerRunning = true;
        }

        private ISessionFactory SessionFactory
        {
            get
            {
                lock (lockObject)
                {
                    return sessionFactory ?? (sessionFactory = SessionFactoryBuilder
                                                         .BuildSessionFactory(ConfigurationManager
                                                         .ConnectionStrings["DefaultConnectionString"].ConnectionString));
                }
            }
        }

        public void Dispose()
        {
            socket.Close();
        }

        public void StartServer()
        {
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, 9999);
                socket.Bind(ip);
                socket.Listen(10);
                Console.WriteLine("Waiting for a client...");
                while (IsServerRunning)
                {
                    Socket client = socket.Accept();
                    Task.Run(() => {
                        IPEndPoint clientEndPoint = (IPEndPoint)client.RemoteEndPoint;
                        Console.WriteLine($"Connected with {clientEndPoint.Address} at port {clientEndPoint.Port}");
                        using (var session = SessionFactory.OpenSession())
                        {
                            var messages = session
                                .QueryOver<Message>()
                                .JoinQueryOver(m => m.Attachments)
                                .TransformUsing(Transformers.DistinctRootEntity)
                                .List();
                            var messageVms = mapper.Map<IList<MessageVm>>(messages);
                            Console.WriteLine("Transmitting data...");
                            var messagesBytes = messageVms.Serialize();
                            client.Send(messagesBytes, messagesBytes.Length, SocketFlags.None);
                            var fileBytes = File.ReadAllBytes("./Attachments/Attachment1.bin");
                            client.Send(fileBytes, fileBytes.Length, SocketFlags.None);
                            fileBytes = File.ReadAllBytes("./Attachments/Attachment1.bin");
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

        public void StopServer()
        {
            IsServerRunning = false;
        }
    }
}
