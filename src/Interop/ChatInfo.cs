using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop
{
    internal class ChatInfo
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }
    }
}