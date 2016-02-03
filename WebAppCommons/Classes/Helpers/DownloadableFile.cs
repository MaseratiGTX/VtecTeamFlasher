using System;

namespace WebAppCommons.Classes.Helpers
{
    [Serializable]
    public class DownloadableFile
    {
        public string FileName { get; set; }
        public byte[] ContentData { get; set; }
        public string ContentText { get; set; }
        public string ContentType { get; set; }  
    }
}