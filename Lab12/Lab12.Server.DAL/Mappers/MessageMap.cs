using FluentNHibernate.Mapping;
using Lab12.Server.Model.Entities;

namespace Lab12.Server.DAL.Mappers
{
    public class MessageMap: ClassMap<Message>
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
