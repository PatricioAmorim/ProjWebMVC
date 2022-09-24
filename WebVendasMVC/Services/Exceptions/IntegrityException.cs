using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendasMVC.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {

        public IntegrityException(string mesage) : base(mesage)
        {

        }

    }
}
