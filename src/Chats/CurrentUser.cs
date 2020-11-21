using HuajiTech.Mirai.ApiHandlers;
using HuajiTech.Mirai.Interop;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义当前用户
    /// </summary>
    public class CurrentUser : User
    {
        internal override Task<string> InternalSendAsync(MessageElement[] message, int? quoteId) => ApiMethods.SendFriendMessageAsync(Session.Settings.HttpUri, Session.SessionKey, Number, quoteId, message);

        /// <summary>
        /// 当前 <see cref="CurrentUser"/> 实例的好友列表
        /// </summary>
        private List<Friend> FriendList;

        /// <summary>
        /// 当前 <see cref="CurrentUser"/> 实例的群列表
        /// </summary>
        private List<Group> GroupList;

        /// <summary>
        /// 当前 <see cref="CurrentUser"/> 实例的好友实例
        /// </summary>
        private Friend Friend;

        /// <summary>
        /// 获取当前 <see cref="CurrentUser"/> 实例的昵称
        /// </summary>
        public string Nickname => Friend?.Nickname;

        /// <summary>
        /// 异步刷新当前 <see cref="CurrentUser"/> 实例的好友列表
        /// </summary>
        public Task RefreshFriendsAsync() => GetFriendListAsync(true);

        /// <summary>
        /// 异步刷新当前 <see cref="CurrentUser"/> 实例的群列表
        /// </summary>
        public Task RefreshGroupsAsync() => GetGroupListAsync(true);

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的好友列表
        /// </summary>
        public Task<List<Friend>> GetFriendsAsync() => GetFriendListAsync(false);

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的好友列表
        /// </summary>
        /// <param name="refresh">是否刷新</param>
        internal async Task<List<Friend>> GetFriendListAsync(bool refresh)
        {
            if (refresh || FriendList == null)
            {
                var result = await ApiMethods.GetFriendListAsync(Session.Settings.HttpUri, Session.SessionKey);
                FriendList = await Task.Run(GetFriendsFromJson(result).ToList);
                Friend = await GetFriendAsync(Number);
                FriendList.Remove(Friend);
            }

            return FriendList;
        }

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的好友
        /// </summary>
        /// <param name="number">好友号码</param>
        /// <returns></returns>
        public async Task<Friend> GetFriendAsync(long number)
        {
            if (FriendList == null)
            {
                return (await GetFriendListAsync(true)).SingleOrDefault(x => x.Number == number) ?? throw new ChatNotFoundException(typeof(Friend), number);
            }
            else
            {
                var result = (await GetFriendListAsync(false)).SingleOrDefault(x => x.Number == number);
                if (result == null)
                {
                    return (await GetFriendListAsync(true)).SingleOrDefault(x => x.Number == number) ?? throw new ChatNotFoundException(typeof(Friend), number);
                }
                else
                {
                    return result;
                }
            }
        }

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的好友信息列表
        /// </summary>
        /// <param name="friends">以 Json 表达的多个好友信息</param>
        private static IEnumerable<FriendInfo> GetFriendInfoFromJson(string friends) => JsonConvert.DeserializeObject<List<FriendInfo>>(friends);

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的好友列表
        /// </summary>
        /// <param name="friends">以 Json 表达的多个好友信息</param>
        private IEnumerable<Friend> GetFriendsFromJson(string friends) => GetFriendInfoFromJson(friends).Select(x => x.ToFriend(Session));

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的群列表
        /// </summary>
        public Task<List<Group>> GetGroupsAsync() => GetGroupListAsync(false);

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的群列表
        /// </summary>
        /// <param name="refresh">是否刷新</param>
        internal async Task<List<Group>> GetGroupListAsync(bool refresh)
        {
            if (refresh || GroupList == null)
            {
                var result = await ApiMethods.GetGroupListAsync(Session.Settings.HttpUri, Session.SessionKey);
                GroupList = await Task.Run(GetGroupsFromJson(result).ToList);
                await GetGroupExtInfoAsync();
            }

            return GroupList;
        }

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的群额外信息
        /// </summary>
        private async Task<List<Group>> GetGroupExtInfoAsync()
        {
            foreach (var group in GroupList)
            {
                var info = await ApiMethods.GetGroupConfigAsync(Session.Settings.HttpUri, Session.SessionKey, group.Number);
                group.GroupExtInfo = GetGroupExtInfoFromJson(info);
            }

            return GroupList;
        }

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的群
        /// </summary>
        /// <param name="number">群号码</param>
        public async Task<Group> GetGroupAsync(long number)
        {
            if (GroupList == null)
            {
                return (await GetGroupListAsync(true)).SingleOrDefault(x => x.Number == number) ?? throw new ChatNotFoundException(typeof(Group), number);
            }
            else
            {
                var result = (await GetGroupListAsync(false)).SingleOrDefault(x => x.Number == number);
                if (result == null)
                {
                    return (await GetGroupListAsync(true)).SingleOrDefault(x => x.Number == number) ?? throw new ChatNotFoundException(typeof(Group), number);
                }
                else
                {
                    return result;
                }
            }
        }

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的群信息列表
        /// </summary>
        /// <param name="groups">以 Json 表达的多个群信息</param>
        private static IEnumerable<GroupInfo> GetGroupInfoFromJson(string groups) => JsonConvert.DeserializeObject<List<GroupInfo>>(groups);

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的群列表
        /// </summary>
        /// <param name="groups">以 Json 表达的多个群信息</param>
        private IEnumerable<Group> GetGroupsFromJson(string groups) => GetGroupInfoFromJson(groups).Select(x => x.ToGroup(this));

        /// <summary>
        /// 从 Json 中提取成员信息，并创建一个 <see cref="GroupExtInfo"/> 实例
        /// </summary>
        /// <param name="info">以 Json 表达的群信息</param>
        private static GroupExtInfo GetGroupExtInfoFromJson(string info) => JsonConvert.DeserializeObject<GroupExtInfo>(info);

        /// <summary>
        /// 获取当前 <see cref="CurrentUser"/> 实例在指定群的成员
        /// </summary>
        /// <param name="group">群</param>
        /// <param name="role">成员角色</param>
        internal Member GetMember(Group group, MemberRole role) => new(group, Number, Nickname, role);

        /// <summary>
        /// 异步获取指定号码的用户
        /// </summary>
        /// <param name="number">用户号码</param>
        internal async Task<User> GetUserAsync(long number) => Number == number ? (User)this : await GetFriendAsync(number);

        /// <summary>
        /// 创建一个 <see cref="CurrentUser"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="CurrentUser"/> 实例所使用的 Session</param>
        internal CurrentUser(Session session) : base(session, session.BotNumber)
        {
        }
    }
}