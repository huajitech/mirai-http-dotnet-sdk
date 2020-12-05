using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.Messaging
{
    /// <summary>
    /// 表示提及的 <see cref="MessageElement"/>
    /// </summary>
    public class Mention : MessageElement
    {
        /// <inheritdoc/>
        protected override string Type { get; } = "At";

        /// <summary>
        /// 获取当前 <see cref="Mention"/> 实例的目标
        /// </summary>
        [JsonIgnore]
        public Member Target { get; }

        /// <summary>
        /// 获取当前 <see cref="Mention"/> 实例的显示名称
        /// </summary>
        [JsonIgnore]
        public string DisplayName { get; }

        /// <summary>
        /// 指定当前 <see cref="Mention"/> 实例的目标号码
        /// </summary>
        [JsonProperty(PropertyName = "target")]
        internal long TargetNumber => Target.Number;

        /// <summary>
        /// 指定当前 <see cref="Mention"/> 实例的显示
        /// </summary>
        [JsonProperty(PropertyName = "display", NullValueHandling = NullValueHandling.Ignore)]
        internal string Display => "@" + DisplayName;

        /// <summary>
        /// 创建 <see cref="Mention"/> 实例
        /// </summary>
        /// <param name="member">指定 <see cref="Mention"/> 实例的成员</param>
        public Mention(Member member) => Target = member;

        /// <summary>
        /// 创建 <see cref="Mention"/> 实例
        /// </summary>
        /// <param name="member">指定 <see cref="Mention"/> 实例的成员</param>
        /// <param name="displayName">指定 <see cref="Mention"/> 实例的显示名称</param>
        public Mention(Member member, string displayName)
        {
            Target = member;
            DisplayName = displayName;
        }
    }
}