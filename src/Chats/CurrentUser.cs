using HuajiTech.Mirai.Extensions;
using HuajiTech.Mirai.Sessions;
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
        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await HttpSessions.SendFriendMessageAsync(Session.Settings.Uri, Session.SessionKey, Number, message);

        /// <summary>
        /// 当前 <see cref="CurrentUser"/> 实例的好友列表
        /// </summary>
        private List<Friend> FriendList { get; set; } = null;

        /// <summary>
        /// 当前 <see cref="CurrentUser"/> 实例的群列表
        /// </summary>
        private List<Group> GroupList { get; set; } = null;

        /// <summary>
        /// 异步刷新当前 <see cref="CurrentUser"/> 实例的好友列表
        /// </summary>
        public async Task RefreshFriendsAsync() => await GetFriendListAsync(true);

        /// <summary>
        /// 异步刷新当前 <see cref="CurrentUser"/> 实例的群列表
        /// </summary>
        public async Task RefreshGroupsAsync() => await GetGroupListAsync(true);

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的好友列表
        /// </summary>
        public async Task<List<Friend>> GetFriendsAsync() => await GetFriendListAsync(false);

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的好友列表
        /// </summary>
        /// <param name="refresh">是否刷新</param>
        internal async Task<List<Friend>> GetFriendListAsync(bool refresh)
        {
            if (refresh || FriendList == null)
            {
                var result = JArray.Parse(await HttpSessions.GetFriendListAsync(Session.Settings.Uri, Session.SessionKey));
                FriendList = await Task.Run(() => GetFriendsFromJson(result).ToList());
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
                return (await GetFriendListAsync(true)).Where(x => x.Number == number).SingleOrDefault() ?? throw new ChatNotFoundException(typeof(Friend), number);
            }
            else
            {
                var result = (await GetFriendListAsync(false)).Where(x => x.Number == number);
                if (result.Any())
                {
                    return result.SingleOrDefault() ?? throw new ChatNotFoundException(typeof(Friend), number);
                }
                else
                {
                    return (await GetFriendListAsync(true)).Where(x => x.Number == number).SingleOrDefault() ?? throw new ChatNotFoundException(typeof(Friend), number);
                }
            }
        }

        /// <summary>
        /// 从 Json 中提取好友信息，并创建一个 <see cref="Friend"/> 实例
        /// </summary>
        /// <param name="friend">以 Json 表达的好友信息</param>
        private Friend GetFriendFromJson(JObject friend) => new Friend(Session, friend.Value<long>("id"), friend.Value<string>("nickname"), friend.Value<string>("remark").CheckEmpty());

        /// <summary>
        /// 从 Json 中提取多个好友信息，并创建一个 <see cref="List{Friend}"/> 实例
        /// </summary>
        /// <param name="friend">以 Json 表达的多个好友信息</param>
        private IEnumerable<Friend> GetFriendsFromJson(JArray friends) => friends.Select(x => GetFriendFromJson((JObject)x));

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的群列表
        /// </summary>
        public async Task<List<Group>> GetGroupsAsync() => await GetGroupListAsync(false);

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的群列表
        /// </summary>
        /// <param name="refresh">是否刷新</param>
        internal async Task<List<Group>> GetGroupListAsync(bool refresh)
        {
            if (refresh || GroupList == null)
            {
                var result = JArray.Parse(await HttpSessions.GetGroupListAsync(Session.Settings.Uri, Session.SessionKey));
                GroupList = await Task.Run(() => GetGroupsFromJson(result).ToList());
            }

            return GroupList;
        }

        /// <summary>
        /// 异步获取当前 <see cref="CurrentUser"/> 实例的群
        /// </summary>
        /// <param name="number">群号码</param>
        /// <returns></returns>
        public async Task<Group> GetGroupAsync(long number)
        {
            if (GroupList == null)
            {
                return (await GetGroupListAsync(true)).Where(x => x.Number == number).SingleOrDefault() ?? throw new ChatNotFoundException(typeof(Group), number);
            }
            else
            {
                var result = (await GetGroupListAsync(false)).Where(x => x.Number == number);
                if (result.Any())
                {
                    return result.SingleOrDefault() ?? throw new ChatNotFoundException(typeof(Group), number);
                }
                else
                {
                    return (await GetGroupListAsync(true)).Where(x => x.Number == number).SingleOrDefault() ?? throw new ChatNotFoundException(typeof(Group), number);
                }
            }
        }

        /// <summary>
        /// 从 Json 中提取群信息，并创建一个 <see cref="Group"/> 实例
        /// </summary>
        /// <param name="group">以 Json 表达的群信息</param>
        private Group GetGroupFromJson(JObject group) => new Group(Session, group.Value<long>("id"), group.Value<string>("name"));

        /// <summary>
        /// 从 Json 中提取多个群信息，并创建一个 <see cref="List{Group}"/> 实例
        /// </summary>
        /// <param name="friend">以 Json 表达的多个群信息</param>
        private IEnumerable<Group> GetGroupsFromJson(JArray groups) => groups.Select(x => GetGroupFromJson((JObject)x));

        /// <summary>
        /// 创建一个 <see cref="CurrentUser"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="CurrentUser"/> 实例所使用的 Session</param>
        internal CurrentUser(Session session) : base(session, session.Settings.BotNumber)
        {
        }
    }
}