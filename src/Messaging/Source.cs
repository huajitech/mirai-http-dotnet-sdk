using Newtonsoft.Json;

namespace HuajiTech.Mirai.Messaging
{
    internal class Source : MessageElement
    {
        internal override string Type { get; } = "Source";

        [JsonProperty(PropertyName = "id")]
        public int Id { get; }

        [JsonProperty(PropertyName = "time")]
        public int Time { get; }

        public Source(int id) => Id = id;

        public Source(int id, int timestamp)
        {
            Id = id;
            Time = timestamp;
        }
    }
}
