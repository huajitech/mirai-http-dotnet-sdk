using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HuajiTech.Mirai.Interop
{
    [JsonObject(Id = "data")]
    internal class MessageData
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; }

        [JsonProperty(PropertyName = "messageChain")]
        public JArray MessageChain { get; }

        [JsonProperty(PropertyName = "sender")]
        public JObject Sender { get; }

        public MessageData(string type, JArray messageChain, JObject sender)
        {
            Type = type;
            MessageChain = messageChain;
            Sender = sender;
        }
    }
}