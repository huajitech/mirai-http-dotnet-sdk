using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop.Events
{
    internal class FriendRecallEventData : RecallEventData
    {
        [JsonProperty(PropertyName = "operator")]
        public long Operator { get; set; }
    }
}