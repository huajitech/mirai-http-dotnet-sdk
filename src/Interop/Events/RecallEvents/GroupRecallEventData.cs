using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop.Events
{
    internal class GroupRecallEventData : RecallEventData
    {
        [JsonProperty(PropertyName = "operator")]
        public MemberInfo Operator { get; set; }
    }
}