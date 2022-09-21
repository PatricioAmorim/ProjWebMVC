using System;

namespace WebVendasMVC.Services.Exceptions
{
    public class NotfoundException : ApplicationException
    {

        public NotfoundException(string message): base(message)
        {

        }

    }

}
