namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Validation.ErrorObjects
{
    public abstract class BaseErrorObject
    {
        public virtual string Descriptor
        {
            get { return "BASE_ERROR_OBJECT"; }
        }

        public virtual string Message { get; set; }
    }
}