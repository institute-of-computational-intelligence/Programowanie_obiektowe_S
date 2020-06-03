using System;

namespace Lab12.Utilities.VMs
{
    [Serializable]
    public class AttachmentVm
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
    }
}
