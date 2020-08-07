namespace HuajiTech.Mirai
{
    public abstract class User : Chat
    {
        public User(Session session) : base(session)
        {
        }

        public User(Session session, long number) : base(session) => Number = number;
    }
}
