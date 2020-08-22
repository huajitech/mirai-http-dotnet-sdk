﻿using HuajiTech.Mirai.ApiHandlers;
using HuajiTech.Mirai.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义群
    /// </summary>
    public class Group : Chat
    {
        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await ApiMethods.SendGroupMessageAsync(Session.HttpUri, Session.SessionKey, Number, message);

        /// <summary>
        /// 当前 <see cref="Group"/> 实例的名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 当前 <see cref="Group"/> 实例的成员列表
        /// </summary>
        private List<Member> MemberList { get; set; } = null;

        /// <summary>
        /// 获取当前 <see cref="Group"/> 实例的信息
        /// </summary>
        internal GroupInfo GroupInfo { get; set; }

        /// <summary>
        /// 获取 <see cref="Group"/> 实例的公告
        /// </summary>
        public string Announcement => GroupInfo.Announcement.CheckEmpty();

        /// <summary>
        /// 获取 <see cref="Group"/> 实例能否使用坦白说
        /// </summary>
        public bool CanConfessTalk => GroupInfo.CanConfessTalk;

        /// <summary>
        /// 获取 <see cref="Group"/> 实例能否邀请新成员
        /// </summary>
        public bool CanInvite => GroupInfo.CanInvite;

        /// <summary>
        /// 获取 <see cref="Group"/> 实例是否自动审批入群
        /// </summary>
        public bool IsAutoApprove => GroupInfo.IsAutoApprove;

        /// <summary>
        /// 获取 <see cref="Group"/> 实例能否使用匿名功能
        /// </summary>
        public bool CanAnonymous => GroupInfo.CanAnonymous;

        /// <summary>
        /// 获取当前 <see cref="Group"/> 实例的当前用户
        /// </summary>
        internal Member CurrentUser { get; }

        /// <summary>
        /// 异步刷新当前 <see cref="CurrentUser"/> 实例的群列表
        /// </summary>
        public async Task RefreshMembersAsync() => await GetMemberListAsync(true);

        /// <summary>
        /// 异步获取当前 <see cref="Group"/> 实例的成员列表
        /// </summary>
        public async Task<List<Member>> GetMembersAsync() => await GetMemberListAsync(false);

        /// <summary>
        /// 异步获取当前 <see cref="Group"/> 实例的成员列表
        /// </summary>
        /// <param name="refresh">是否刷新</param>
        internal async Task<List<Member>> GetMemberListAsync(bool refresh)
        {
            if (refresh || MemberList == null)
            {
                var result = JArray.Parse(await ApiMethods.GetMemberListAsync(Session.HttpUri, Session.SessionKey, Number));
                MemberList = await Task.Run(GetMembersFromJson(result).ToList);
                MemberList.Add(CurrentUser);
            }

            return await GetMemberInfoAsync();
        }

        /// <summary>
        /// 异步获取当前 <see cref="Group"/> 实例的成员信息
        /// </summary>
        private async Task<List<Member>> GetMemberInfoAsync()
        {
            foreach (var member in MemberList)
            {
                var info = await ApiMethods.GetMemberInfo(Session.HttpUri, Session.SessionKey, Number, member.Number);
                member.MemberInfo = GetMemberInfoFromJson(info);
            }

            return MemberList;
        }

        /// <summary>
        /// 异步获取当前 <see cref="Group"/> 实例的成员
        /// </summary>
        /// <param name="number">群号码</param>
        /// <returns></returns>
        public async Task<Member> GetMemberAsync(long number)
        {
            if (MemberList == null)
            {
                return (await GetMemberListAsync(true)).Where(x => x.Number == number).SingleOrDefault() ?? throw new ChatNotFoundException(typeof(Member), number);
            }
            else
            {
                var result = (await GetMemberListAsync(false)).Where(x => x.Number == number);
                if (result.Any())
                {
                    return result.SingleOrDefault() ?? throw new ChatNotFoundException(typeof(Member), number);
                }
                else
                {
                    return (await GetMemberListAsync(true)).Where(x => x.Number == number).SingleOrDefault() ?? throw new ChatNotFoundException(typeof(Member), number);
                }
            }
        }

        /// <summary>
        /// 从 Json 中提取群信息，并创建一个 <see cref="Member"/> 实例
        /// </summary>
        /// <param name="member">以 Json 表达的群信息</param>
        private Member GetMemberFromJson(JObject member) => new Member(this, member.Value<long>("id"), member.Value<string>("memberName"), Member.MemberRoleDictionary[member.Value<string>("permission")]);

        /// <summary>
        /// 从 Json 中提取多个群信息，并创建一个 <see cref="List{Member}"/> 实例
        /// </summary>
        /// <param name="members">以 Json 表达的多个群信息</param>
        private IEnumerable<Member> GetMembersFromJson(JArray members) => members.Select(x => GetMemberFromJson((JObject)x));

        /// <summary>
        /// 从 Json 中提取成员信息，并创建一个 <see cref="MemberInfo"/> 实例
        /// </summary>
        /// <param name="info">以 Json 表达的成员信息</param>
        private MemberInfo GetMemberInfoFromJson(string info) => JsonConvert.DeserializeObject<MemberInfo>(info);

        /// <summary>
        /// 禁言当前 <see cref="Group"/> 实例
        /// </summary>
        public async Task MuteAsync() => (await ApiMethods.MuteAllAsync(Session.HttpUri, Session.SessionKey, Number)).CheckError();

        /// <summary>
        /// 解除当前 <see cref="Group"/> 实例的禁言
        /// </summary>
        public async Task UnmuteAsync() => (await ApiMethods.UnmuteAllAsync(Session.HttpUri, Session.SessionKey, Number)).CheckError();

        /// <summary>
        /// 离开当前 <see cref="Group"/> 实例
        /// </summary>
        public async Task LeaveAsync() => (await ApiMethods.QuitAsync(Session.HttpUri, Session.SessionKey, Number)).CheckError();

        /// <summary>
        /// 设置当前 <see cref="Group"/> 实例的名称
        /// </summary>
        /// <param name="name">将要设定的名称</param>
        public async Task SetName(string name)
        {
            (await ApiMethods.GroupConfig(Session.HttpUri, Session.SessionKey, Number, new { name })).CheckError();
            Name = name;
        }

        /// <summary>
        /// 设置当前 <see cref="Group"/> 实例的公告
        /// </summary>
        /// <param name="announcement">将要设定的公告</param>
        public async Task SetAnnouncement(string announcement)
        {
            (await ApiMethods.GroupConfig(Session.HttpUri, Session.SessionKey, Number, new { announcement })).CheckError();
            GroupInfo.Announcement = announcement;
        }

        /// <summary>
        /// 设置当前 <see cref="Group"/> 实例的坦白说
        /// </summary>
        /// <param name="enabled">是否启用</param>
        internal async Task SetConfessTalk(bool enabled)
        {
            (await ApiMethods.GroupConfig(Session.HttpUri, Session.SessionKey, Number, new { confessTalk = enabled })).CheckError();
            GroupInfo.CanConfessTalk = enabled;
        }

        /// <summary>
        /// 启用当前 <see cref="Group"/> 实例的坦白说
        /// </summary>
        public async Task EnableConfessTalk() => await SetConfessTalk(true);

        /// <summary>
        /// 禁用当前 <see cref="Group"/> 实例的坦白说
        /// </summary>
        /// <param name="enabled">是否启用</param>
        public async Task DisableConfessTalk() => await SetConfessTalk(false);

        /// <summary>
        /// 设置当前 <see cref="Group"/> 实例的邀请
        /// </summary>
        /// <param name="allowed">是否允许</param>
        internal async Task SetInvite(bool allowed)
        {
            (await ApiMethods.GroupConfig(Session.HttpUri, Session.SessionKey, Number, new { allowMemberInvite = allowed })).CheckError();
            GroupInfo.CanInvite = allowed;
        }

        /// <summary>
        /// 允许当前 <see cref="Group"/> 实例邀请新成员
        /// </summary>
        public async Task AllowInvite() => await SetInvite(true);

        /// <summary>
        /// 不允许当前 <see cref="Group"/> 实例邀请新成员
        /// </summary>
        public async Task DisallowInvite() => await SetInvite(false);

        /// <summary>
        /// 设置当前 <see cref="Group"/> 实例的自动审批入群
        /// </summary>
        /// <param name="enabled">是否启用</param>
        internal async Task SetAutoApprove(bool enabled)
        {
            (await ApiMethods.GroupConfig(Session.HttpUri, Session.SessionKey, Number, new { autoApprove = enabled })).CheckError();
            GroupInfo.IsAutoApprove = enabled;
        }

        /// <summary>
        /// 启用当前 <see cref="Group"/> 实例的自动审批入群
        /// </summary>
        public async Task EnableAutoApprove() => await SetAutoApprove(true);

        /// <summary>
        /// 禁用当前 <see cref="Group"/> 实例的自动审批入群
        /// </summary>
        public async Task DisableAutoApprove() => await SetAutoApprove(false);

        /// <summary>
        /// 设置当前 <see cref="Group"/> 实例的匿名功能
        /// </summary>
        /// <param name="enabled">是否启用</param>
        internal async Task SetAnonymous(bool enabled)
        {
            (await ApiMethods.GroupConfig(Session.HttpUri, Session.SessionKey, Number, new { anonymousChat = enabled })).CheckError();
            GroupInfo.CanAnonymous = enabled;
        }

        /// <summary>
        /// 启用当前 <see cref="Group"/> 实例的匿名功能
        /// </summary>
        public async Task EnableAnonymous() => await SetAnonymous(true);

        /// <summary>
        /// 禁用当前 <see cref="Group"/> 实例的匿名功能
        /// </summary>
        public async Task DisableAnonymous() => await SetAnonymous(false);

        /// <summary>
        /// 创建 <see cref="Group"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="Group"/> 实例所使用的 Session</param>
        /// <param name="number">指定 <see cref="Group"/> 实例的号码</param>
        internal Group(Session session, long number, string name, CurrentUser currentUser, MemberRole currentUserRole) : base(session, number)
        {
            Name = name;
            CurrentUser = currentUser.GetMember(this, currentUserRole);
        }
    }
}