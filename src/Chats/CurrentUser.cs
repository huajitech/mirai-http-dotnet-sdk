using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public class CurrentUser : User
    {
        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await HttpSessions.SendFriendMessage(CurrentSession.Settings.Uri, CurrentSession.SessionKey, Number, message);

        public CurrentUser(Session session) : base(session)
        {
            Number = session.Settings.BotNumber;
        }
    }
}
