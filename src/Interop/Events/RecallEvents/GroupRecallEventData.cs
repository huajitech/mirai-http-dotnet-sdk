using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.Interop.Events
{
    internal class GroupRecallEventData : RecallEventData
    {
        [JsonProperty(PropertyName = "group")]
        public GroupInfo Group { get; init; }

        [JsonProperty(PropertyName = "operator")]
        public MemberInfo Operator { get; init; }
    }
}