namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.FilterKeyProviders
{
    public interface IFilterKeyProvider<T> where T : class
    {
        string ProvideKeyFor(T source);
    }
}