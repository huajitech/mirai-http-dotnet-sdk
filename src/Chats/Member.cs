﻿using HuajiTech.Mirai.ApiHandlers;
using HuajiTech.Mirai.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义成员
    /// </summary>
    public class Member : User
    {
        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await ApiMethods.SendTempMessageAsync(Session.HttpUri, Session.SessionKey, Number, Group.Number, message);

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
        internal MemberInfo MemberInfo { get; set; }

        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例的群名片
        /// </summary>
        public string Alias => MemberInfo.Name.CheckEmpty();

        /// <summary>
        /// 获取当前 <see cref="Member"/> 实例的头衔
        /// </summary>
        public string Title => MemberInfo.Title.CheckEmpty();

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
        /// 禁言当前 <see cref="Member"/> 实例
        /// </summary>
        /// <param name="time">禁言时长</param>
        public async Task MuteAsync(TimeSpan time)
        {
            if (time.TotalSeconds < 0 || time > TimeSpan.FromDays(30))
            {
                throw new OverflowException();
            }
            else
            {
                (await ApiMethods.MuteAsync(Session.HttpUri, Session.SessionKey, Group.Number, Number, (int)time.TotalSeconds)).CheckError();
            }
        }

        /// <summary>
        /// 解除当前 <see cref="Member"/> 实例的禁言
        /// </summary>
        public async Task UnmuteAsync() => (await ApiMethods.UnmuteAsync(Session.HttpUri, Session.SessionKey, Group.Number, Number)).CheckError();

        /// <summary>
        /// 移除当前 <see cref="Member"/> 实例
        /// </summary>
        /// <param name="msg">移除消息</param>
        public async Task KickAsync(string msg = null) => (await ApiMethods.KickAsync(Session.HttpUri, Session.SessionKey, Group.Number, Number, msg)).CheckError();

        /// <summary>
        /// 创建 <see cref="Member"/> 实例
        /// </summary>
        /// <param name="group">指定 <see cref="Member"/> 实例所在的群</param>
        /// <param name="number">指定 <see cref="Member"/> 实例的号码</param>
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
        Owner,
        Administrator,
        Member
    }
}