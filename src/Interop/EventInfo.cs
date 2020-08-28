using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop
{
    internal class EventInfo
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}