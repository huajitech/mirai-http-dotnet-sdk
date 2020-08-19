using HuajiTech.Mirai.ApiHandlers;
using HuajiTech.Mirai.Extensions;
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
        /// 当前 <see cref="Group"/> 实例的成员列表
        /// </summary>
        private List<Member> MemberList { get; set; } = null;

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
                MemberList = await Task.Run(() => GetMembersFromJson(result).ToList());
                MemberList.Add(CurrentUser);
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
        /// 禁言当前 <see cref="Group"/> 实例
        /// </summary>
        public async Task MuteAsync() => JObject.Parse(await ApiMethods.MuteAllAsync(Session.HttpUri, Session.SessionKey, Number)).CheckError();

        /// <summary>
        /// 解除当前 <see cref="Group"/> 实例的禁言
        /// </summary>
        public async Task UnmuteAsync() => JObject.Parse(await ApiMethods.UnmuteAllAsync(Session.HttpUri, Session.SessionKey, Number)).CheckError();

        /// <summary>
        /// 离开当前 <see cref="Group"/> 实例
        /// </summary>
        public async Task LeaveAsync() => JObject.Parse(await ApiMethods.QuitAsync(Session.HttpUri, Session.SessionKey, Number)).CheckError();

        /// <summary>
        /// 创建 <see cref="Group"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="Group"/> 实例所使用的 Session</param>
        /// <param name="number">指定 <see cref="Group"/> 实例的号码</param>
        internal Group(Session session, long number, string name, CurrentUser currentUser, MemberRole currentUserRole) : base(session, number, name) => CurrentUser = new Member(this, currentUser.Number, currentUser.Name, currentUserRole);
    }
}