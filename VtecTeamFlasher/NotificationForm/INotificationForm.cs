namespace VtecTeamFlasher.NotificationForm
{
    public interface INotificationForm<T>
    {
        T SetConfiguration(INotificationFormConfiguration configuration);
        T SetMessage(string message);

        T ShowForm();
        void CloseForm();
    }

    public delegate void WrapedCodeDelegate();
}