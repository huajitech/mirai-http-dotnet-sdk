using System;
using System.Runtime.Serialization;

namespace HuajiTech.Mirai
{
    public class ApiException : Exception
    {
        public int ErrorCode { get; }

        public ApiException()
        {
        }

        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ApiException(string message, int code) : base(message) => ErrorCode = code;
    }
}