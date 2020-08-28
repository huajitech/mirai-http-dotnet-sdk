using Newtonsoft.Json;

namespace HuajiTech.Mirai.Interop
{
    /// <summary>
    /// 定义群额外信息
    /// </summary>
    internal class GroupExtInfo
    {
        /// <summary>
        /// 获取 <see cref="GroupExtInfo"/> 实例的公告
        /// </summary>
        [JsonProperty(PropertyName = "announcement")]
        public string Announcement { get; set; }

        /// <summary>
        /// 获取 <see cref="GroupExtInfo"/> 实例能否使用坦白说
        /// </summary>
        [JsonProperty(PropertyName = "confessTalk")]
        public bool CanConfessTalk { get; set; }

        /// <summary>
        /// 获取 <see cref="GroupExtInfo"/> 实例能否邀请新成员
        /// </summary>
        [JsonProperty(PropertyName = "allowMemberInvite")]
        public bool CanInvite { get; set; }

        /// <summary>
        /// 获取 <see cref="GroupExtInfo"/> 实例是否自动审批入群
        /// </summary>
        [JsonProperty(PropertyName = "autoApprove")]
        public bool IsAutoApprove { get; set; }

        /// <summary>
        /// 获取 <see cref="GroupExtInfo"/> 实例能否使用匿名功能
        /// </summary>
        [JsonProperty(PropertyName = "anonymousChat")]
        public bool CanAnonymous { get; set; }
    }
}