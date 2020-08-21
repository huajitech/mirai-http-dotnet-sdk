using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop
{
    internal class ErrorInfo
    {
        [JsonProperty(PropertyName = "code")]
        public int ErrorCode { get; }

        [JsonProperty(PropertyName = "msg")]
        public string Message { get; }

        public ErrorInfo(int code, string msg)
        {
            ErrorCode = code;
            Message = msg;
        }
    }
}