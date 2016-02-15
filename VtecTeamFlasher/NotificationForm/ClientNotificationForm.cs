using System.Windows.Forms;

namespace VtecTeamFlasher.NotificationForm
{
    public partial class ClientNotificationForm : Form, INotificationForm<ClientNotificationForm>
    {
        private ClientNotificationFormConfiguration configuration = new ClientNotificationFormConfiguration();



        public ClientNotificationForm()
        {
            InitializeComponent();
        }

        public ClientNotificationForm(string message)
        {
            InitializeComponent();

            configuration.Message = message;
        }



        #region INotificationForm<ClientNotificationForm> Members

        public ClientNotificationForm SetConfiguration(INotificationFormConfiguration configuration)
        {
            this.configuration = (ClientNotificationFormConfiguration)configuration;

            return this;
        }

        public ClientNotificationForm SetMessage(string message)
        {
            configuration.Message = message;

            return this;
        }

        public ClientNotificationForm ShowForm()
        {
            InitializeControls();

            Show();
            Update();

            if (configuration.Parent != null) configuration.Parent.Update();

            return this;
        }

        public void CloseForm()
        {
            Close();
        }

        #endregion


        private void InitializeControls()
        {
            lblNotification.Text = configuration.Message;


            if (configuration.Parent == null)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                StartPosition = FormStartPosition.Manual;
                Location = LocationUtils.GetLocationToCenterControl(this, configuration.Parent);
            }
        }



        public ClientNotificationForm For(WrapedCodeDelegate wrapedCodeDelegate)
        {
            configuration.WrapedCode = wrapedCodeDelegate;

            return this;
        }


        public ClientNotificationForm SetParent(Form parent)
        {
            configuration.Parent = parent;

            return this;
        }

        public ClientNotificationForm SetMainFormAsParent()
        {
            configuration.Parent = configuration.MainForm;

            return this;
        }



        public ClientNotificationForm SetCursor(Cursor cursor)
        {
            configuration.Cursor = cursor;

            return this;
        }



        public void ExecuteWrapedCodeWithNotification()
        {
            if (configuration.WrapedCode == null) return;


            ShowForm();

            ExecuteWrapedCode();

            CloseForm();
        }

        private void ExecuteWrapedCode()
        {
            if (configuration.WrapedCode == null) return;



            Cursor savedParentCursor = configuration.Parent != null ? configuration.Parent.Cursor : null;
            bool isParentCursorWasChanged = false;


            try
            {
                if (configuration.Cursor != null && configuration.Parent != null)
                {
                    configuration.Parent.Cursor = configuration.Cursor;
                    isParentCursorWasChanged = true;
                }

                configuration.WrapedCode();
            }
            catch
            {
                CloseForm();

                throw;
            }
            finally
            {
                if (isParentCursorWasChanged) configuration.Parent.Cursor = savedParentCursor;
            }
        }
    }
}