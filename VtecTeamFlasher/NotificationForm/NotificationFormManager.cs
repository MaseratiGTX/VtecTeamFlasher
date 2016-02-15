namespace VtecTeamFlasher.NotificationForm
{
    public class NotificationFormManager<T> where T: INotificationForm<T>, new()
    {
        private readonly INotificationFormConfiguration defaultConfiguration;
        
        private T notificationFormInstance;



        public NotificationFormManager(){}

        public NotificationFormManager(INotificationFormConfiguration defaultConfiguration)
        {
            this.defaultConfiguration = defaultConfiguration;
        }



        public T CreateForm(string message)
        {
            T result = new T();
            
            if (defaultConfiguration != null)
            {
                result.SetConfiguration((INotificationFormConfiguration) defaultConfiguration.Clone());
            }

            result.SetMessage(message);


            return result;
        }


        public void ShowForm(string message)
        {
            CloseForm();

            notificationFormInstance = CreateForm(message);
            notificationFormInstance.ShowForm();
        }

        public void CloseForm()
        {
            if (notificationFormInstance.Equals(default(T)))
            {
                notificationFormInstance.CloseForm();
                notificationFormInstance = default(T);
            }
        }
    }
}