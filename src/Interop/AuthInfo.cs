using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop
{
    internal class AuthInfo
    {
        [JsonProperty(PropertyName = "session")]
        public string SessionKey { get; init; }
    }
}