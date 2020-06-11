using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Lab12.Server.Model.Entities;
using System.Threading.Tasks;

namespace Lab12.Server.DAL.Mappers
{
    public class AttachmentMap : ClassMap<Attachment>
    {
        public AttachmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Extension)
                .Not.Nullable();
            Map(x => x.FileName)
                .Not.Nullable();
            Map(x => x.Size)
                .Not.Nullable();
            References(x => x.Message)
                .Not
                .LazyLoad()
                .Column("MessageId")
                .Cascade.All();
        }
    }
}