using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lab12.Server.DAL;
using Lab12.Server.Model.Entities;
using Lab12.Server.Utilities.VMs;
using NHibernate;

namespace Lab12.Server
{
    class Program
    {
        private static ISessionFactory _factory;
        static void Main(string[] args)
        {
            try
            {
                if (!Directory.Exists(@"./Attachments/"))
                    Directory.CreateDirectory(@"./Attachments/");
                
                FileStream attachementFileA = new FileStream(@"./Attachments/FileA.bin", FileMode.OpenOrCreate);
                attachementFileA.SetLength(8*1024);
                attachementFileA.Close();

                FileStream attachementFileB = new FileStream(@"./Attachments/FileB.bin", FileMode.OpenOrCreate);
                attachementFileB.SetLength(32*512);
                attachementFileB.Close();

                IMapper autoMapper = SetupAutoMapper();

                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
                _factory = SessionFactoryBuilder.BuildSessionFactory(connectionString, true);

                //var projDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
                //AppDomain.CurrentDomain.SetData("DataDirectory", $@"{projDir}\Lab12.Server");

                using (var newSession = _factory.OpenSession())
                {
                    Message message = new Message()
                    {
                        Text = "First message",
                        Title = "MSG"
                    };

                    newSession.Save(message);

                    var attachmentsDir = new DirectoryInfo(@"./Attachments/");
                    foreach (var fileInfo in attachmentsDir.GetFiles())
                    {
                        var attachment = new Attachment
                        {
                            Message = message,
                            Extension = fileInfo.Extension,
                            FileName = fileInfo.Name,
                            Size = fileInfo.Length
                        };
                        message.Attachments.Add(attachment);
                        newSession.Save(attachment);
                    }
                }

                IServerListener serverListener = new ServerListener(autoMapper);
                serverListener.StartServer();
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
            }

            Console.ReadLine();
        }

        private static IMapper SetupAutoMapper()
        {
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Message, MessageVm>();
                x.CreateMap<Attachment, AttachmentVm>();
            });

            return new Mapper(mapperConfiguration);
        }
    }
}
