using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.Interop.Events
{
    internal class BotGroupPermissionChangeEventData
    {
        [JsonProperty(PropertyName = "origin")]
        public string Origin { get; set; }

        [JsonProperty(PropertyName = "current")]
        public string Current { get; set; }

        [JsonProperty(PropertyName = "group")]
        public GroupInfo Group { get; set; }
    }
}