using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HuajiTech.Mirai.Interop.Messaging
{
    internal class QuoteInfo
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "groupId")]
        public long GroupId { get; set; }

        [JsonProperty(PropertyName = "senderId")]
        public long SenderId { get; set; }

        [JsonProperty(PropertyName = "targetId")]
        public long TargetId { get; set; }

        [JsonProperty(PropertyName = "origin")]
        public JArray Origin { get; set; }
    }
}