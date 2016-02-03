namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Validation.ErrorObjects
{
    public class SourceElementValidationErrorObject : BaseErrorObject
    {
        public override string Descriptor
        {
            get { return "SOURCE_ELEMENT_VALIDATION_ERROR_OBJECT"; }
        }

        public virtual string FieldName { get; set; }
    }
}