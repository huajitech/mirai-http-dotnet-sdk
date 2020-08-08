using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义成员
    /// </summary>
    public class Member : User
    {
        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例所在的群
        /// </summary>
        public Group Group { get; }

        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await HttpSessions.SendTempMessageAsync(Session.Settings.Uri, Session.SessionKey, Number, Group.Number, message);

        /// <summary>
        /// 创建 <see cref="Member"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="Member"/> 实例所使用的 Session</param>
        /// <param name="group">指定 <see cref="Member"/> 实例所在的群</param>
        /// <param name="number">指定 <see cref="Member"/> 实例的号码</param>
        public Member(Session session, long group, long number) : base(session, number) => Group = new Group(session, group);

        /// <summary>
        /// 创建 <see cref="Member"/> 实例
        /// </summary>
        /// <param name="group">指定 <see cref="Member"/> 实例所在的群</param>
        /// <param name="number">指定 <see cref="Member"/> 实例的号码</param>
        public Member(Group group, long number) : base(group.Session, number) => Group = group;
    }
}