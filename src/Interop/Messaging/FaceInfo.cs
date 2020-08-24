using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop.Messaging
{
    internal class FaceInfo
    {
        [JsonProperty(PropertyName = "faceId")]
        public int Id { get; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; }

        public Emoticon ToEmoticon() => new Emoticon(Id, Name);

        public FaceInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}