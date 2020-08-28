using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HuajiTech.Mirai.Interop
{
    internal class MessageData
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "messageChain")]
        public JArray MessageChain { get; set; }

        [JsonProperty(PropertyName = "sender")]
        public JObject Sender { get; set; }
    }
}