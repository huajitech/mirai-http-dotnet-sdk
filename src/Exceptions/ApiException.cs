using System;
using System.Runtime.Serialization;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 调用 API 时所引发的异常
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// 获取 <see cref="ApiException"/> 实例的错误代码
        /// </summary>
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

        /// <summary>
        /// 创建 <see cref="ApiException"/> 实例
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误代码</param>
        public ApiException(string message, int code) : base(message) => ErrorCode = code;
    }
}