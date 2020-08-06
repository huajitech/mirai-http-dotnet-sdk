using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public class Group : Chat
    {
        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await HttpSessions.SendGroupMessage(CurrentSession.Settings.Uri, CurrentSession.SessionKey, Number, message);

        public Group(Session session, long number) : base(session) => Number = number;
    }
}