using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDiOperator.SDK.Exceptions
{
    /// <summary>
    /// Ошибка - неверных логин или пароль.
    /// </summary>
    public class LoginErrorException : Exception
    {
        public LoginErrorException(string message) : base(message) { }
    }
}
