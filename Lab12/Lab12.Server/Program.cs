using System;
using System.Configuration;
using System.IO;
using AutoMapper;
using Lab12.Server.DAL;
using Lab12.Server.Model.Entities;
using Lab12.Utilities.VMs;
using NHibernate;

namespace Lab12.Server
{
    class Program
    {
        private static ISessionFactory _sessionFactory;

        public static IMapper SetupAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Message, MessageVm>();
                cfg.CreateMap<Attachment, AttachmentVm>();
            });
            return new Mapper(config);
        }
        static void Main()
        {
            try
            {
                var mapper = SetupAutoMapper();
                if (!Directory.Exists(@"./Attachments/"))
                {
                    Directory.CreateDirectory(@"./Attachments/");
                }
                FileStream fs = new FileStream(@"./Attachments/Attachment1.bin", FileMode.OpenOrCreate);
                long fileSize = 1024 * 1024;
                fs.SetLength(fileSize);
                fs.Close();
                fs = new FileStream(@"./Attachments/Attachment2.bin", FileMode.OpenOrCreate);
                fileSize = 1024 * 1024 * 10;
                fs.SetLength(fileSize);
                fs.Close();
                var workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.Parent?.FullName;
                AppDomain.CurrentDomain.SetData("DataDirectory", $@"{projectDirectory}\Lab12.Server");
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
                _sessionFactory = SessionFactoryBuilder.BuildSessionFactory(connectionString, true);
                Console.WriteLine("Database Created successfully");

                using (var session = _sessionFactory.OpenSession())
                {
                    Message message = new Message()
                    {
                        Text = "This is a new message",
                        Title = "New msg"
                    };
                    session.Save(message);
                    var di = new DirectoryInfo(@"./Attachments/");
                    foreach (var fileInfo in di.GetFiles())
                    {
                        var attachment = new Attachment
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
