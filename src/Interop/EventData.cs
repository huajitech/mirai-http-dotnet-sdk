using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop
{
    internal class EventData
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}