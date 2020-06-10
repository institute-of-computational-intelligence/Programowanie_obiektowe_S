using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12.Server.Utilities.VMs
{
    [Serializable]
    public class AttachmentVm
    {
        public virtual int ID { get; set; }
        public virtual string FileName { get; set; }
        public virtual string Extension { get; set; }
        public virtual long Size { get; set; }
    }
}
