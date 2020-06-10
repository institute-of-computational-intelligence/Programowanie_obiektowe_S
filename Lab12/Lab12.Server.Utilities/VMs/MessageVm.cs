using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12.Server.Utilities.VMs
{
    [Serializable]
    public class MessageVm
    {
        public virtual int ID { get; set; }
        public virtual string Title { get; set; }
        public virtual string Text { get; set; }
        public virtual IList<AttachmentVm> Attachments { get; set; }

        public MessageVm()
        {
            Attachments = new List<AttachmentVm>();
        }
    }
}
