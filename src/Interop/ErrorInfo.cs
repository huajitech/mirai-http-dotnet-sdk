using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop
{
    /// <summary>
    /// 定义错误信息
    /// </summary>
    internal class ErrorInfo
    {
        /// <summary>
        /// 获取当前 <see cref="ErrorInfo"/> 实例的错误代码
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int ErrorCode { get; }

        /// <summary>
        /// 获取当前 <see cref="ErrorInfo"/> 实例的消息
        /// </summary>
        [JsonProperty(PropertyName = "msg")]
        public string Message { get; }

        /// <summary>
        /// 创建 <see cref="ErrorInfo"/> 实例
        /// </summary>
        /// <param name="code">指定 <see cref="ErrorInfo"/> 实例的错误代码</param>
        /// <param name="msg">指定 <see cref="ErrorInfo"/> 实例的消息</param>
        public ErrorInfo(int code, string msg)
        {
            ErrorCode = code;
            Message = msg;
        }
    }
}