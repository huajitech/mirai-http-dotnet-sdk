using System.Collections.Generic;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义成员
    /// </summary>
    public class Member : User
    {
        public string Name { get; }

        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例所在的群
        /// </summary>
        public Group Group { get; }

        public MemberRole MemberRole { get; }

        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await HttpSessions.SendTempMessageAsync(Session.Settings.Uri, Session.SessionKey, Number, Group.Number, message);

        internal static readonly Dictionary<string, MemberRole> MemberRoleDictionary = new Dictionary<string, MemberRole>()
        {
            ["OWNER"] = MemberRole.Owner,
            ["ADMINISTRATOR"] = MemberRole.Administrator,
            ["MEMBER"] = MemberRole.Member
        };

        /// <summary>
        /// 创建 <see cref="Member"/> 实例
        /// </summary>
        /// <param name="group">指定 <see cref="Member"/> 实例所在的群</param>
        /// <param name="number">指定 <see cref="Member"/> 实例的号码</param>
        /// <param name="role">指定 <see cref="Member"/> 实例的成员角色</param>
        internal Member(Group group, long number, string name, MemberRole role) : base(group.Session, number)
        {
            Name = name;
            MemberRole = role;
        }
    }

    public enum MemberRole
    {
        Owner,
        Administrator,
        Member
    }
}