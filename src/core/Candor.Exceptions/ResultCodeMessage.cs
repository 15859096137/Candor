using System;
using System.Collections.Generic;
using System.Text;

namespace Candor.Exceptions
{
    public static class ResultCodes
    {
        public const int BaseError = 100;
        public const int InvalidAction = 200;
        public const int InvalidParameter = 300;
        public const int BadRequest = 400;
        public const int Unauthorized = 401;
        public const int Forbidden = 403;
        public const int NotFound = 404;
        public const int InternalServerError = 500;
    }

    public static class ResultCodeMessage
    {
        private static readonly Dictionary<int, string> messages = new Dictionary<int, string>
        {
            { ResultCodes.BaseError, "Base error message" },
            { ResultCodes.InvalidAction, "Invalid action error message" },
            { ResultCodes.InvalidParameter, "Invalid parameter error message" },
            { ResultCodes.BadRequest, "Bad Request" },
            { ResultCodes.Unauthorized, "Unauthorized" },
            { ResultCodes.Forbidden, "Forbidden" },
            { ResultCodes.NotFound, "Not Found" },
            { ResultCodes.InternalServerError, "Internal Server Error" }
        };

        public static string GetMessage(int errorCode)
        {
            if (messages.ContainsKey(errorCode))
            {
                return messages[errorCode];
            }
            else
            {
                return "Unknown error";
            }
        }
    }
}
