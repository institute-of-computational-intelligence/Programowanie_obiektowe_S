using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12.Server.Model.Entities
{
    public class Message
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Text { get; set; }
        public virtual IList<Attachment> Attachments { get; set; }

        public Message()
        {
            Attachments = new List<Attachment>();
        }
    }
}
