using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public class CurrentUser : User
    {
        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await HttpSessions.SendFriendMessage(CurrentSession.Settings.Uri, CurrentSession.SessionKey, Number, message);

        private List<Friend> FriendList { get; set; } = null;

        public async Task<List<Friend>> GetFriendListAsync() => await GetFriendListAsync(false);

        public async Task<List<Friend>> GetFriendListAsync(bool refresh)
        {
            if (refresh || FriendList == null)
            {
                var result = JArray.Parse(await HttpSessions.GetFriendList(CurrentSession.Settings.Uri, CurrentSession.SessionKey));
                FriendList = await Task.Run(() => GetFriendsFromJson(result).ToList());
            }

            return FriendList;
        }

        private Friend GetFriendFromJson(JObject friend) => new Friend(CurrentSession, friend.Value<long>("id"), friend.Value<string>("nickname"), friend.Value<string>("remark"));

        private IEnumerable<Friend> GetFriendsFromJson(JArray friends) => friends.Select(x => GetFriendFromJson((JObject)x));

        public CurrentUser(Session session) : base(session)
        {
            Number = session.Settings.BotNumber;
        }
    }
}
