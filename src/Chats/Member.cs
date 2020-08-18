using HuajiTech.Mirai.ApiHandlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义成员
    /// </summary>
    public class Member : User
    {
        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await ApiMethods.SendTempMessageAsync(Session.Settings.HttpUri, Session.SessionKey, Number, Group.Number, message);

        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例的名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例所在的群
        /// </summary>
        public Group Group { get; }

        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例的角色
        /// </summary>
        public MemberRole Role { get; }

        /// <summary>
        /// 成员角色 <see cref="string"/> 对 <see cref="MemberRole"/> 的字典
        /// </summary>
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
            Role = role;
        }
    }

    /// <summary>
    /// 指定成员角色
    /// </summary>
    public enum MemberRole
    {
        Owner,
        Administrator,
        Member
    }
}