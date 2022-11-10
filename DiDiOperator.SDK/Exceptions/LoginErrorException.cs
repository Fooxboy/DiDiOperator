using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDiOperator.SDK.Exceptions
{
    public class LoginErrorException : Exception
    {
        public LoginErrorException(string message) : base(message)
        {

        }
    }
}
