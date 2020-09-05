using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop.Events
{
    internal class RecallEventData
    {
        [JsonProperty(PropertyName = "authorId")]
        public long AuthorId { get; set; }

        [JsonProperty(PropertyName = "messageId")]
        public int MessageId { get; set; }
    }
}