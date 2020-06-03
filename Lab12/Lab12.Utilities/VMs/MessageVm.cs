using System;
using System.Collections.Generic;
using Lab12.Utilities.Attributes;

namespace Lab12.Utilities.VMs
{
    [Serializable]
    public class MessageVm
    {
        public  int Id { get; set; }
        public  string Title { get; set; }
        public  string Text { get; set; }
        [Hide]
        public  IList<AttachmentVm> Attachments { get; set; }

        public MessageVm()
        {
            Attachments = new List<AttachmentVm>();
        }

    }
}
