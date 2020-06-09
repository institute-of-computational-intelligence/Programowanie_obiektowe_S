using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12.Server.Model.Entities
{
    public class Attachment
    {
        public virtual int Id { get; set; }
        public virtual string FileName { get; set; }
        public virtual string Extension { get; set; }
        public virtual long Size { get; set; }

        public virtual Message Message { get; set; }

        
    }
}
