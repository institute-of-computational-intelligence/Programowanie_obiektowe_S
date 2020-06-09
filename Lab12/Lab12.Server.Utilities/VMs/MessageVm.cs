using Lab12.Server.Utilities.Attributes;
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
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        [Hide]
        IList<AttachmentVm> Attachments { get; set; }

        public MessageVm()
        {
            Attachments = new List<AttachmentVm>();
        }

    }
}
