using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop.Messaging
{
    internal class FaceInfo
    {
        [JsonProperty(PropertyName = "faceId")]
        public int Id { get; init; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; init; }

        public Emoticon ToEmoticon() => new Emoticon(Id, Name);
    }
}