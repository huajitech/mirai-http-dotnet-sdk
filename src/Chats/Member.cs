using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public class Member : User
    {
        public Group Group { get; }

        internal override async Task<string> InternalSendAsync(MessageElement[] message) => await HttpSessions.SendTempMessage(CurrentSession.Settings.Uri, CurrentSession.SessionKey, Number, Group.Number, message);

        public Member(Session session, long group, long target) : base(session, target) => Group = new Group(session, group);

        public Member(Session session, Group group, long target) : base(session, target) => Group = group;
    }
}