using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.Interop
{
    internal class EventData
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; init; }
    }
}