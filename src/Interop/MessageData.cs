using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HuajiTech.Mirai.Interop
{
    internal class MessageData
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; init; }

        [JsonProperty(PropertyName = "messageChain")]
        public JArray MessageChain { get; init; }

        [JsonProperty(PropertyName = "sender")]
        public JObject Sender { get; init; }
    }
}