using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Lab12.Server.DAL.Mappers;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Lab12.Server.DAL
{
    public static class SessionFactoryBuilder
    {
        public static ISessionFactory BuildSessionFactory(string connectionString, bool createDb = false)
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
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
