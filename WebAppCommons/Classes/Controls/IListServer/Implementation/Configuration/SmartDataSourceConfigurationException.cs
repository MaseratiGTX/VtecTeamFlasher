using Commons.Validation.Exceptions;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.Configuration
{
    public class SmartDataSourceConfigurationException : ValidationException
    {
        public SmartDataSourceConfigurationException(string message) : base(message)
        {
        }

        public SmartDataSourceConfigurationException(string message, string fieldName) : base(message, fieldName)
        {
        }
    }
}