using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HuajiTech.Mirai.Interop.Messaging
{
    internal class QuoteInfo
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; }

        [JsonProperty(PropertyName = "groupId")]
        public long GroupId { get; }

        [JsonProperty(PropertyName = "senderId")]
        public long SenderId { get; }

        [JsonProperty(PropertyName = "targetId")]
        public long TargetId { get; }

        [JsonProperty(PropertyName = "origin")]
        public JArray Origin { get; }

        public QuoteInfo(int id, long groupId, long senderId, long targetId, JArray origin)
        {
            Id = id;
            GroupId = groupId;
            SenderId = senderId;
            TargetId = targetId;
            Origin = origin;
        }
    }
}