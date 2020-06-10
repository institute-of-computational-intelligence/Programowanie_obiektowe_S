using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Attachment = Lab12.Server.Model.Entities.Attachment;

namespace Lab12.Server.DAL.Mappers
{
    public class AttachmentMap : ClassMap<Attachment>
    {
        public AttachmentMap()
        {
            Id(memberExpression: x => x.ID);
            Map(memberExpression: x => x.Extension)
                .Not.Nullable();
            Map(memberExpression: x => x.FileName)
                .Not.Nullable();
            Map(memberExpression: x => x.Size)
                .Not.Nullable();
            References(memberExpression: x => x.Message)
                .Not
                .LazyLoad()
                .Column("MessageId")
                .Cascade.All();
        }
    }
}
