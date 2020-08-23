using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Interop
{
    internal class FriendSenderInfo : SenderInfo
    {
        [JsonProperty(PropertyName = "nickname")]
        public string Nickname { get; }

        [JsonProperty(PropertyName = "remark")]
        public string Remark { get; }

        public Friend ToFriend(Session session) => new Friend(session, Id, Nickname, Remark);

        public async Task<Friend> GetFriendAsync(CurrentUser currentUser) => await currentUser.GetFriendAsync(Id);

        public FriendSenderInfo(long id, string remark) : base(id) => Remark = remark;
    }
}