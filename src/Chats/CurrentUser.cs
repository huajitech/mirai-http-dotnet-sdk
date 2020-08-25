using HuajiTech.Mirai.ApiHandlers;
using HuajiTech.Mirai.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        internal override Task<string> InternalSendAsync(MessageElement[] message) => ApiMethods.SendFriendMessageAsync(Session.HttpUri, Session.SessionKey, Number, message);

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
                var result = JArray.Parse(await ApiMethods.GetFriendListAsync(Session.HttpUri, Session.SessionKey));
                FriendList = await Task.Run(GetFriendsFromJson(result).ToList);
                Friend = await GetFriendAsync(Number);
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
        /// 从 Json 中提取好友信息，并创建一个 <see cref="Mirai.Friend"/> 实例
        /// </summary>
        /// <param name="friend">以 Json 表达的好友信息</param>
        private Friend GetFriendFromJson(JObject friend) => new Friend(Session, friend.Value<long>("id"), friend.Value<string>("nickname"), friend.Value<string>("remark").CheckEmpty());

        /// <summary>
        /// 从 Json 中提取多个好友信息，并创建一个 <see cref="List{Friend}"/> 实例
        /// </summary>
        /// <param name="friends">以 Json 表达的多个好友信息</param>
        private IEnumerable<Friend> GetFriendsFromJson(JArray friends) => friends.Select(x => GetFriendFromJson((JObject)x));

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
                var result = JArray.Parse(await ApiMethods.GetGroupListAsync(Session.HttpUri, Session.SessionKey));
                GroupList = await Task.Run(GetGroupsFromJson(result).ToList);
            }

            return await GetGroupInfoAsync();
        }

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的群信息
        /// </summary>
        private async Task<List<Group>> GetGroupInfoAsync()
        {
            foreach (var group in GroupList)
            {
                var info = await ApiMethods.GetGroupConfig(Session.HttpUri, Session.SessionKey, group.Number);
                group.GroupInfo = GetGroupInfoFromJson(info);
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
        /// 从 Json 中提取群信息，并创建一个 <see cref="Group"/> 实例
        /// </summary>
        /// <param name="group">以 Json 表达的群信息</param>
        private Group GetGroupFromJson(JObject group) => new Group(this, group.Value<long>("id"), group.Value<string>("name"), Member.MemberRoleDictionary[group.Value<string>("permission")]);

        /// <summary>
        /// 从 Json 中提取多个群信息，并创建一个 <see cref="List{Group}"/> 实例
        /// </summary>
        /// <param name="groups">以 Json 表达的多个群信息</param>
        private IEnumerable<Group> GetGroupsFromJson(JArray groups) => groups.Select(x => GetGroupFromJson((JObject)x));

        /// <summary>
        /// 从 Json 中提取成员信息，并创建一个 <see cref="GroupInfo"/> 实例
        /// </summary>
        /// <param name="info">以 Json 表达的群信息</param>
        private GroupInfo GetGroupInfoFromJson(string info) => JsonConvert.DeserializeObject<GroupInfo>(info);

        /// <summary>
        /// 异步获取指定 ID 的消息
        /// </summary>
        /// <param name="id">消息 ID</param>
        /// <returns>指定 ID 的 <see cref="Message"/> 实例</returns>
        public Task<Message> GetMessageAsync(int id) => Message.GetMessageAsync(this, id);

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例在指定群的成员
        /// </summary>
        /// <param name="group">群</param>
        /// <param name="role">成员角色</param>
        internal Member GetMember(Group group, MemberRole role) => new Member(group, Number, Nickname, role);

        /// <summary>
        /// 创建一个 <see cref="CurrentUser"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="CurrentUser"/> 实例所使用的 Session</param>
        internal CurrentUser(Session session) : base(session, session.BotNumber)
        {
        }
    }
}