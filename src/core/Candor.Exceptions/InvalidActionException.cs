using System;
using System.Collections.Generic;
using System.Text;

namespace Candor.Exceptions
{

    public class InvalidActionException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidActionException"/> class with a specified error message and error code.
        /// </summary>
        /// <remarks>
        /// You can throw an <see cref="InvalidActionException"/> with different error messages and error codes like this:
        /// <code>
        /// throw new InvalidActionException();
        /// throw new InvalidActionException("Custom error message");
        /// throw new InvalidActionException(errorCode: 300);
        /// throw new InvalidActionException("Custom error message", 300);
        /// </code>
        ///</remarks>
        public InvalidActionException(string message = null, int errorCode = 200) : base(message ?? ResultCodeMessage.GetMessage(errorCode), errorCode)
        {
        }
    }

}
