using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Interop
{
    internal class FriendInfo : ChatInfo
    {
        [JsonProperty(PropertyName = "nickname")]
        public string Nickname { get; init; }

        [JsonProperty(PropertyName = "remark")]
        public string Remark { get; init; }

        public Friend ToFriend(Session session) => new(session, Id, Nickname, Remark.CheckEmpty());

        public async Task<Friend> GetFriendAsync(CurrentUser currentUser) => await currentUser.GetFriendAsync(Id);
    }
}