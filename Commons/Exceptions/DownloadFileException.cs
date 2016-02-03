using System;

namespace Commons.Exceptions
{
    public class DownloadFileException : Exception
    {
        public DownloadFileException()
        {
        }

        public DownloadFileException(string message) : base(message)
        {
        }
        
        public DownloadFileException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}