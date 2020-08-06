using Newtonsoft.Json;

namespace HuajiTech.Mirai.Messaging
{
    public class Emoticon : MessageElement
    {
        internal override string Type { get; } = "Face";

        [JsonProperty(PropertyName = "faceId", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; }

        public Emoticon()
        {
        }

        public Emoticon(int id) => Id = id;

        public Emoticon(string name) => Name = name;
    }
}