using System;

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

        /// <summary>
        /// 创建 <see cref="ApiException"/> 实例
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误代码</param>
        internal ApiException(string message, int code) : base(string.Format(Resources.UnexpectedReturnValue, code, message)) => ErrorCode = code;
    }
}