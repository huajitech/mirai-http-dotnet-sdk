using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop
{
    internal class AuthInfo
    {
        [JsonProperty(PropertyName = "session")]
        public string SessionKey { get; }

        public AuthInfo(string sessionKey) => SessionKey = sessionKey;
    }
}