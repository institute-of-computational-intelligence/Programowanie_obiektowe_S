using FluentNHibernate.Mapping;
using Lab12.Server.Model.Entities;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12.Server.DAL.Mappers
{
    public class MessageMap : ClassMap<Message>
    { 
        public MessageMap()
        {
            Id(x => x.Id);
            Map(x => x.Text)
                .Not.Nullable();
            Map(x => x.Title)
                .Not.Nullable();
            HasMany(x => x.Attachments).Not.LazyLoad();
        }
    }
}
