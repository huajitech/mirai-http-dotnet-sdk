using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop
{
    internal class SenderInfo
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; }

        public SenderInfo(long id) => Id = id;
    }
}