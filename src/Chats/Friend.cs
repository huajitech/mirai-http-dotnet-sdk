using System;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public class Friend : User
    {
        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await HttpSessions.SendFriendMessage(CurrentSession.Settings.Uri, CurrentSession.SessionKey, Number, message);

        public string Nickname { get; private set; }

        public string Alias { get; private set; }

        public async Task GetFriendInfo(CurrentUser currentUser) => await GetFriendInfo(currentUser, false);

        public async Task GetFriendInfo(CurrentUser currentUser, bool refresh)
        {
            var friend = (await currentUser.GetFriendListAsync(refresh)).Where(this.Equals).SingleOrDefault() ?? throw new InvalidOperationException();
            Nickname = friend.Nickname;
            Alias = friend.Alias;
        }

        public Friend(Session session, long number) : base(session, number)
        {
        }

        internal Friend(Session session, long number, string nickname, string alias) : base(session, number)
        {
            Nickname = nickname;
            Alias = alias;
        }
    }
}