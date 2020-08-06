using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public class Friend : User
    {
        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await HttpSessions.SendFriendMessage(CurrentSession.Settings.Uri, CurrentSession.SessionKey, Number, message);

        public Friend(Session session, long number) : base(session, number)
        {
        }
    }
}