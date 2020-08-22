using Newtonsoft.Json;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义群信息
    /// </summary>
    [JsonObject(Id = "config")]
    internal class GroupInfo
    {
        /// <summary>
        /// 获取 <see cref="GroupInfo"/> 实例的公告
        /// </summary>
        [JsonProperty(PropertyName = "announcement")]
        public string Announcement { get; set; }

        /// <summary>
        /// 获取 <see cref="GroupInfo"/> 实例能否使用坦白说
        /// </summary>
        [JsonProperty(PropertyName = "confessTalk")]
        public bool CanConfessTalk { get; set; }

        /// <summary>
        /// 获取 <see cref="GroupInfo"/> 实例能否邀请新成员
        /// </summary>
        [JsonProperty(PropertyName = "allowMemberInvite")]
        public bool CanInvite { get; set; }

        /// <summary>
        /// 获取 <see cref="GroupInfo"/> 实例是否自动审批入群
        /// </summary>
        [JsonProperty(PropertyName = "autoApprove")]
        public bool IsAutoApprove { get; set; }

        /// <summary>
        /// 获取 <see cref="GroupInfo"/> 实例能否使用匿名功能
        /// </summary>
        [JsonProperty(PropertyName = "anonymousChat")]
        public bool CanAnonymous { get; set; }

        /// <summary>
        /// 创建 <see cref="GroupInfo"/> 实例
        /// </summary>
        /// <param name="announcement">指定 <see cref="GroupInfo"/> 实例的公告</param>
        /// <param name="canConfessTalk">指定 <see cref="GroupInfo"/> 实例能否使用坦白说</param>
        /// <param name="canInvite">指定 <see cref="GroupInfo"/> 实例能否邀请新成员</param>
        /// <param name="isAutoApprove">指定 <see cref="GroupInfo"/> 实例是否自动审批入群</param>
        /// <param name="canAnonymous">指定 <see cref="GroupInfo"/> 实例能否使用匿名功能</param>
        public GroupInfo(string announcement, bool canConfessTalk, bool canInvite, bool isAutoApprove, bool canAnonymous)
        {
            Announcement = announcement;
            CanConfessTalk = canConfessTalk;
            CanInvite = canInvite;
            IsAutoApprove = isAutoApprove;
            CanAnonymous = canAnonymous;
        }
    }
}