using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.Interop
{
    internal class ChatInfo
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }
    }
}