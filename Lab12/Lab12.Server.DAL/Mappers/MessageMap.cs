using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Lab12.Server.Model.Entities;

namespace Lab12.Server.DAL.Mappers
{
    public class MessageMap: ClassMap<Message>
    {
        public MessageMap()
        {
            Id(memberExpression: x => x.ID);
            Map(memberExpression: x => x.Text)
                .Not.Nullable();
            Map(memberExpression: x => x.Title)
                .Not.Nullable();
            HasMany(memberExpression: x => x.Attachments).Not.LazyLoad();
        }
    }
}
