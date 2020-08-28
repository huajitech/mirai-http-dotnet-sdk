using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Interop
{
    internal class FriendInfo : ChatInfo
    {
        [JsonProperty(PropertyName = "nickname")]
        public string Nickname { get; set; }

        [JsonProperty(PropertyName = "remark")]
        public string Remark { get; set; }

        public Friend ToFriend(Session session) => new Friend(session, Id, Nickname, Remark);

        public async Task<Friend> GetFriendAsync(CurrentUser currentUser) => await currentUser.GetFriendAsync(Id);
    }
}