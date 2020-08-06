namespace HuajiTech.Mirai
{
    public class SessionProcessor
    {
        internal Session CurrentSession { get; private set; }

        internal void SetCurrentSession(Session session) => CurrentSession = session;

        internal SessionProcessor() => CurrentSession = null;

        internal SessionProcessor(Session session) => CurrentSession = session;
    }
}