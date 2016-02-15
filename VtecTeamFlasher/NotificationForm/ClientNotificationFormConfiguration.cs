using System.Windows.Forms;

namespace VtecTeamFlasher.NotificationForm
{
    public class ClientNotificationFormConfiguration : INotificationFormConfiguration
    {
        private string message;
        private WrapedCodeDelegate wrapedCode;

        private Form parent;
        private Form mainForm;
        
        private Cursor cursor;



        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public WrapedCodeDelegate WrapedCode
        {
            get { return wrapedCode; }
            set { wrapedCode = value; }
        }

        public Form Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public Form MainForm
        {
            get { return mainForm; }
            set { mainForm = value; }
        }

        public Cursor Cursor
        {
            get { return cursor; }
            set { cursor = value; }
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}