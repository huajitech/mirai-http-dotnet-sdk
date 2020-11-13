using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop.Events
{
    internal class RecallEventData
    {
        [JsonProperty(PropertyName = "authorId")]
        public long AuthorId { get; init; }

        [JsonProperty(PropertyName = "messageId")]
        public int MessageId { get; init; }
    }
}