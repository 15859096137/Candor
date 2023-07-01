using System;
using System.Collections.Generic;
using System.Text;

namespace Candor.Exceptions
{
    public class BaseException : Exception
    {
        public int ResultCode { get; }

        public BaseException(string message, int resultCode) : base(message)
        {
            ResultCode = resultCode;
        }
    }
}
