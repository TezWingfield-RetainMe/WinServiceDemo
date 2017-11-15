using System;

namespace WinServiceDemo.Common.CustomExceptions
{
    public class EmailException : Exception
    {
        public EmailException()
            : base()
        {

        }
        public EmailException(string message)
            : base(message)
        {

        }
        public EmailException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
