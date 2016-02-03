using System;

namespace WebAreaCommons.Classes.Items
{
    [Serializable]
    public class EDocumentSignatureCheckingItem
    {
        public string Status { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string ImageToolTip { get; set; }
    }
}