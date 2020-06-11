using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lab12.Server.DAL.Mappers;

namespace Lab12.Server.DAL
{
    public class SessionFactoryBuilder
    {
        public static ISessionFactory BuildSessionFactory(string connectionString, bool createDb = false)
        {
            var configuration = Fluently.Configure().
                Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AttachmentMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MessageMap>())
                .BuildConfiguration();
            if (!createDb)
                return configuration.BuildSessionFactory();
            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);
            return configuration.BuildSessionFactory();
        }
    }
}
