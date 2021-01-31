using HuajiTech.Mirai.Http.ApiHandlers;
using HuajiTech.Mirai.Http.Interop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 定义成员
    /// </summary>
    public class Member : User
    {
        /// <inheritdoc/>
        private protected override Task<string> InternalSendAsync(MessageElement[] message, int? quoteId) => ApiMethods.SendTempMessageAsync(Session.Settings.HttpUri, Session.SessionKey, Number, Group.Number, quoteId, message);

        /// <inheritdoc/>
        public override string ToString() => $"{nameof(Member)}({Number},{Group.Number})";

        /// <summary>
        /// 当前 <see cref="Member"/> 实例的昵称
        /// </summary>
        public string Nickname { get; }

        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例所在的群
        /// </summary>
        public Group Group { get; }

        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例的角色
        /// </summary>
        public MemberRole Role { get; }

        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例的信息
        /// </summary>
        internal MemberExtInfo MemberExtInfo { get; set; }

        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例的群名片
        /// </summary>
        public string Alias => MemberExtInfo.Name.CheckEmpty();

        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例的头衔
        /// </summary>
        public string Title => MemberExtInfo.Title.CheckEmpty();

        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例的显示名称
        /// </summary>
        public string DisplayName => Alias ?? Nickname;

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
        /// 异步禁言当前 <see cref="Member"/> 实例
        /// </summary>
        /// <param name="time">禁言时长</param>
        public async Task MuteAsync(TimeSpan time)
        {
            if (time.TotalSeconds <= 0 || time > TimeSpan.FromDays(30))
            {
                throw new ArgumentOutOfRangeException(nameof(time));
            }
            else
            {
                (await ApiMethods.MuteAsync(Session.Settings.HttpUri, Session.SessionKey, Group.Number, Number, (int)time.TotalSeconds)).CheckError();
            }
        }

        /// <summary>
        /// 异步解除当前 <see cref="Member"/> 实例的禁言
        /// </summary>
        public async Task UnmuteAsync() => (await ApiMethods.UnmuteAsync(Session.Settings.HttpUri, Session.SessionKey, Group.Number, Number)).CheckError();

        /// <summary>
        /// 异步移除当前 <see cref="Member"/> 实例
        /// </summary>
        /// <param name="msg">移除消息</param>
        public async Task KickAsync(string msg = null) => (await ApiMethods.KickAsync(Session.Settings.HttpUri, Session.SessionKey, Group.Number, Number, msg)).CheckError();

        /// <summary>
        /// 异步设置当前 <see cref="Member"/> 实例的群名片
        /// </summary>
        /// <param name="alias">将要设定的群名片</param>
        public async Task SetAliasAsync(string alias)
        {
            (await ApiMethods.MemberInfoAsync(Session.Settings.HttpUri, Session.SessionKey, Group.Number, Number, new { name = alias })).CheckError();
            MemberExtInfo.Name = alias;
        }

        /// <summary>
        /// 异步设置当前 <see cref="Member"/> 实例的头衔
        /// </summary>
        /// <param name="title">将要设定的头衔</param>
        public async Task SetTitleAsync(string title)
        {
            (await ApiMethods.MemberInfoAsync(Session.Settings.HttpUri, Session.SessionKey, Group.Number, Number, new { specialTitle = title })).CheckError();
            MemberExtInfo.Title = title;
        }

        /// <summary>
        /// 创建 <see cref="Member"/> 实例
        /// </summary>
        /// <param name="group">指定 <see cref="Member"/> 实例所在的群</param>
        /// <param name="number">指定 <see cref="Member"/> 实例的号码</param>
        /// <param name="name">指定 <see cref="Member"/> 实例的名称</param>
        /// <param name="role">指定 <see cref="Member"/> 实例的成员角色</param>
        internal Member(Group group, long number, string name, MemberRole role) : base(group.Session, number)
        {
            Nickname = name;
            Group = group;
            Role = role;
        }
    }

    /// <summary>
    /// 指定成员角色
    /// </summary>
    public enum MemberRole
    {
        /// <summary>
        /// 群主
        /// </summary>
        Owner,

        /// <summary>
        /// 管理员
        /// </summary>
        Administrator,

        /// <summary>
        /// 成员
        /// </summary>
        Member
    }
}