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
        public int ErrorCode { get; init; }

        /// <summary>
        /// 获取当前 <see cref="ErrorInfo"/> 实例的消息
        /// </summary>
        [JsonProperty(PropertyName = "msg")]
        public string Message { get; init; }
    }
}