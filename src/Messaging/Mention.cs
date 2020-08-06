using Newtonsoft.Json;

namespace HuajiTech.Mirai.Messaging
{
    public class Mention : MessageElement
    {
        internal override string Type { get; } = "At";

        [JsonIgnore]
        public Member Target { get; }

        [JsonIgnore]
        public string DisplayName { get; }

        [JsonProperty(PropertyName = "target")]
        internal long? TargetNumber => Target.Number;

        [JsonProperty(PropertyName = "display", NullValueHandling = NullValueHandling.Ignore)]
        internal string Display => "@" + DisplayName;

        public Mention(Member member) => Target = member;

        public Mention(Member member, string displayName)
        {
            Target = member;
            DisplayName = displayName;
        }
    }
}