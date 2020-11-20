using HuajiTech.Mirai.ApiHandlers;
using HuajiTech.Mirai.Interop;
using Newtonsoft.Json;
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
        internal override Task<string> InternalSendAsync(MessageElement[] message, int? quoteId) => ApiMethods.SendGroupMessageAsync(Session.Settings.HttpUri, Session.SessionKey, Number, quoteId, message);

        /// <summary>
        /// 当前 <see cref="Group"/> 实例的名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 当前 <see cref="Group"/> 实例的成员列表
        /// </summary>
        private List<Member> MemberList;

        /// <summary>
        /// 获取当前 <see cref="Group"/> 实例的信息
        /// </summary>
        internal GroupExtInfo GroupExtInfo { get; set; }

        /// <summary>
        /// 获取 <see cref="Group"/> 实例的公告
        /// </summary>
        public string Announcement => GroupExtInfo.Announcement.CheckEmpty();

        /// <summary>
        /// 获取 <see cref="Group"/> 实例能否使用坦白说
        /// </summary>
        public bool CanConfessTalk => GroupExtInfo.CanConfessTalk;

        /// <summary>
        /// 获取 <see cref="Group"/> 实例能否邀请新成员
        /// </summary>
        public bool CanInvite => GroupExtInfo.CanInvite;

        /// <summary>
        /// 获取 <see cref="Group"/> 实例是否自动审批入群
        /// </summary>
        public bool IsAutoApprove => GroupExtInfo.IsAutoApprove;

        /// <summary>
        /// 获取 <see cref="Group"/> 实例能否使用匿名功能
        /// </summary>
        public bool CanAnonymous => GroupExtInfo.CanAnonymous;

        /// <summary>
        /// 获取当前 <see cref="Group"/> 实例的当前用户
        /// </summary>
        internal Member CurrentUser { get; }

        /// <summary>
        /// 异步刷新当前 <see cref="Group"/> 实例的成员列表
        /// </summary>
        public Task RefreshMembersAsync() => GetMemberListAsync(true);

        /// <summary>
        /// 异步获取当前 <see cref="Group"/> 实例的成员列表
        /// </summary>
        public Task<List<Member>> GetMembersAsync() => GetMemberListAsync(false);

        /// <summary>
        /// 异步获取当前 <see cref="Group"/> 实例的成员列表
        /// </summary>
        /// <param name="refresh">是否刷新</param>
        internal async Task<List<Member>> GetMemberListAsync(bool refresh)
        {
            if (refresh || MemberList == null)
            {
                var result = await ApiMethods.GetMemberListAsync(Session.Settings.HttpUri, Session.SessionKey, Number);
                MemberList = await Task.Run(GetMembersFromJson(result).ToList);
                MemberList.Add(CurrentUser);
                await GetMemberExtInfoAsync();
            }

            return MemberList;
        }

        /// <summary>
        /// 异步获取当前 <see cref="Group"/> 实例的成员信息
        /// </summary>
        private async Task<List<Member>> GetMemberExtInfoAsync()
        {
            foreach (var member in MemberList)
            {
                var info = await ApiMethods.GetMemberInfo(Session.Settings.HttpUri, Session.SessionKey, Number, member.Number);
                member.MemberExtInfo = GetMemberExtInfoFromJson(info);
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
                return (await GetMemberListAsync(true)).SingleOrDefault(x => x.Number == number) ?? throw new ChatNotFoundException(typeof(Member), number);
            }
            else
            {
                var result = (await GetMemberListAsync(false)).SingleOrDefault(x => x.Number == number);
                if (result == null)
                {
                    return (await GetMemberListAsync(true)).SingleOrDefault(x => x.Number == number) ?? throw new ChatNotFoundException(typeof(Member), number);
                }
                else
                {
                    return result;
                }
            }
        }

        /// <summary>
        /// 异步获取当前 <see cref="Group"/> 实例的成员信息列表
        /// </summary>
        /// <param name="members">以 Json 表达的多个成员信息</param>
        private static IEnumerable<MemberInfo> GetMemberInfoFromJson(string members) => JsonConvert.DeserializeObject<List<MemberInfo>>(members);

        /// <summary>
        /// 异步获取当前 <see cref="Group"/> 实例的成员信息列表
        /// </summary>
        /// <param name="members">以 Json 表达的多个成员信息</param>
        private IEnumerable<Member> GetMembersFromJson(string members) => GetMemberInfoFromJson(members).Select(x => x.ToMember(this));

        /// <summary>
        /// 从 Json 中提取成员信息，并创建一个 <see cref="MemberExtInfo"/> 实例
        /// </summary>
        /// <param name="info">以 Json 表达的成员信息</param>
        private static MemberExtInfo GetMemberExtInfoFromJson(string info) => JsonConvert.DeserializeObject<MemberExtInfo>(info);

        /// <summary>
        /// 异步禁言当前 <see cref="Group"/> 实例
        /// </summary>
        public async Task MuteAsync() => (await ApiMethods.MuteAllAsync(Session.Settings.HttpUri, Session.SessionKey, Number)).CheckError();

        /// <summary>
        /// 异步解除当前 <see cref="Group"/> 实例的禁言
        /// </summary>
        public async Task UnmuteAsync() => (await ApiMethods.UnmuteAllAsync(Session.Settings.HttpUri, Session.SessionKey, Number)).CheckError();

        /// <summary>
        /// 异步离开当前 <see cref="Group"/> 实例
        /// </summary>
        public async Task LeaveAsync() => (await ApiMethods.QuitAsync(Session.Settings.HttpUri, Session.SessionKey, Number)).CheckError();

        /// <summary>
        /// 异步设置当前 <see cref="Group"/> 实例的名称
        /// </summary>
        /// <param name="name">将要设定的名称</param>
        public async Task SetNameAsync(string name)
        {
            (await ApiMethods.GroupConfig(Session.Settings.HttpUri, Session.SessionKey, Number, new { name })).CheckError();
            Name = name;
        }

        /// <summary>
        /// 异步设置当前 <see cref="Group"/> 实例的公告
        /// </summary>
        /// <param name="announcement">将要设定的公告</param>
        public async Task SetAnnouncementAsync(string announcement)
        {
            (await ApiMethods.GroupConfig(Session.Settings.HttpUri, Session.SessionKey, Number, new { announcement })).CheckError();
            GroupExtInfo.Announcement = announcement;
        }

        /// <summary>
        /// 异步设置当前 <see cref="Group"/> 实例的坦白说
        /// </summary>
        /// <param name="enabled">是否启用</param>
        private async Task SetConfessTalkAsync(bool enabled)
        {
            (await ApiMethods.GroupConfig(Session.Settings.HttpUri, Session.SessionKey, Number, new { confessTalk = enabled })).CheckError();
            GroupExtInfo.CanConfessTalk = enabled;
        }

        /// <summary>
        /// 异步启用当前 <see cref="Group"/> 实例的坦白说
        /// </summary>
        public Task EnableConfessTalkAsync() => SetConfessTalkAsync(true);

        /// <summary>
        /// 异步禁用当前 <see cref="Group"/> 实例的坦白说
        /// </summary>
        public Task DisableConfessTalkAsync() => SetConfessTalkAsync(false);

        /// <summary>
        /// 异步设置当前 <see cref="Group"/> 实例的邀请
        /// </summary>
        /// <param name="allowed">是否允许</param>
        private async Task SetInviteAsync(bool allowed)
        {
            (await ApiMethods.GroupConfig(Session.Settings.HttpUri, Session.SessionKey, Number, new { allowMemberInvite = allowed })).CheckError();
            GroupExtInfo.CanInvite = allowed;
        }

        /// <summary>
        /// 异步允许当前 <see cref="Group"/> 实例邀请新成员
        /// </summary>
        public Task AllowInviteAsync() => SetInviteAsync(true);

        /// <summary>
        /// 异步不允许当前 <see cref="Group"/> 实例邀请新成员
        /// </summary>
        public Task DisallowInviteAsync() => SetInviteAsync(false);

        /// <summary>
        /// 异步设置当前 <see cref="Group"/> 实例的自动审批入群
        /// </summary>
        /// <param name="enabled">是否启用</param>
        private async Task SetAutoApproveAsync(bool enabled)
        {
            (await ApiMethods.GroupConfig(Session.Settings.HttpUri, Session.SessionKey, Number, new { autoApprove = enabled })).CheckError();
            GroupExtInfo.IsAutoApprove = enabled;
        }

        /// <summary>
        /// 异步启用当前 <see cref="Group"/> 实例的自动审批入群
        /// </summary>
        public Task EnableAutoApproveAsync() => SetAutoApproveAsync(true);

        /// <summary>
        /// 异步禁用当前 <see cref="Group"/> 实例的自动审批入群
        /// </summary>
        public Task DisableAutoApproveAsync() => SetAutoApproveAsync(false);

        /// <summary>
        /// 异步设置当前 <see cref="Group"/> 实例的匿名功能
        /// </summary>
        /// <param name="enabled">是否启用</param>
        private async Task SetAnonymousAsync(bool enabled)
        {
            (await ApiMethods.GroupConfig(Session.Settings.HttpUri, Session.SessionKey, Number, new { anonymousChat = enabled })).CheckError();
            GroupExtInfo.CanAnonymous = enabled;
        }

        /// <summary>
        /// 异步启用当前 <see cref="Group"/> 实例的匿名功能
        /// </summary>
        public Task EnableAnonymousAsync() => SetAnonymousAsync(true);

        /// <summary>
        /// 异步禁用当前 <see cref="Group"/> 实例的匿名功能
        /// </summary>
        public Task DisableAnonymousAsync() => SetAnonymousAsync(false);

        /// <summary>
        /// 创建 <see cref="Group"/> 实例
        /// </summary>
        /// <param name="currentUser">指定 <see cref="Group"/> 实例的当前用户</param>
        /// <param name="number">指定 <see cref="Group"/> 实例的号码</param>
        /// <param name="name">指定 <see cref="Group"/> 实例的名称</param>
        /// <param name="currentUserRole">指定 <see cref="Group"/> 实例的当前用户角色</param>
        internal Group(CurrentUser currentUser, long number, string name, MemberRole currentUserRole) : base(currentUser.Session, number)
        {
            Name = name;
            CurrentUser = currentUser.GetMember(this, currentUserRole);
        }
    }
}