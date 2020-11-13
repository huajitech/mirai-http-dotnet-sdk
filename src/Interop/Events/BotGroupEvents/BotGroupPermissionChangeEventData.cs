using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop.Events
{
    internal class BotGroupPermissionChangeEventData
    {
        [JsonProperty(PropertyName = "origin")]
        public string Origin { get; init; }

        [JsonProperty(PropertyName = "current")]
        public string Current { get; init; }

        [JsonProperty(PropertyName = "group")]
        public GroupInfo Group { get; init; }
    }
}