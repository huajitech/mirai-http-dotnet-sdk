using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HuajiTech.Mirai.Http.Interop.Messaging
{
    internal class QuoteInfo
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; init; }

        [JsonProperty(PropertyName = "groupId")]
        public long GroupId { get; init; }

        [JsonProperty(PropertyName = "senderId")]
        public long SenderId { get; init; }

        [JsonProperty(PropertyName = "targetId")]
        public long TargetId { get; init; }

        [JsonProperty(PropertyName = "origin")]
        public JArray Origin { get; init; }
    }
}