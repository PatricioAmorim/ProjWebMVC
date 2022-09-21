using System;

namespace WebVendasMVC.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {

        public DbConcurrencyException(string mensage) : base(mensage)
        {

        }
    }
}
