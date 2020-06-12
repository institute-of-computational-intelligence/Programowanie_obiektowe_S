using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AutoMapper;
using Lab12.Server.DAL;
using Lab12.Server.Model.Entities;
using Lab12.Server.Utilities.VMs;
using NHibernate;
using System.Configuration;


namespace Lab12.Server
{
    class Program
    {
        private static ISessionFactory _sessionFactory;

        static void Main(string[] args)
        {
            try
            {
                if (!Directory.Exists(@"./Attachments/"))
                    Directory.CreateDirectory(@"./Attachments/");

                FileStream fileStream = new FileStream(@"./Attachments/attachment1.bin", FileMode.OpenOrCreate);
                fileStream.SetLength(1024 * 1024);
                fileStream.Close();
                fileStream = new FileStream(@"./Attachments/attachment2.bin", FileMode.OpenOrCreate);
                fileStream.SetLength(1024 * 1024 * 10);
                fileStream.Close();

                IMapper mapper = SetupAutoMapper();

                String directory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", $@"{directory}\Lab12.Server");

                String connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
                _sessionFactory = SessionFactoryBuilder.BuildSessionFactory(connectionString, true);
                Console.WriteLine("Database Created successfully");

                using (ISession session = _sessionFactory.OpenSession())
                {
                    Message message = new Message()
                    {
                        Text = "This is a new message",
                        Title = "New message"
                    };
                    session.Save(message);

                    DirectoryInfo directoryInfo = new DirectoryInfo(@"./Attachments/");
                    foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                    {
                        Attachment attachment = new Attachment
                        {
                            Message = message,
                            Extension = fileInfo.Extension,
                            FileName = fileInfo.Name,
                            Size = fileInfo.Length
                        };
                        message.Attachments.Add(attachment);
                        session.Save(attachment);
                    }
                }
                IServerListener serverListener = new ServerListener(mapper);
                serverListener.StartServer();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

            Console.ReadKey();
        }

        private static IMapper SetupAutoMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(e =>
            {
                e.CreateMap<Message, MessageVm>();
                e.CreateMap<Attachment, AttachmentVm>();
            });

            return new Mapper(mapperConfiguration);
        }
    }
}
