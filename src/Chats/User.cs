namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义用户
    /// </summary>
    public abstract class User : Chat
    {
        /// <summary>
        /// 创建 <see cref="User"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="User"/> 实例所使用的 Session</param>
        /// <param name="number">指定 <see cref="User"/> 实例的号码</param>
        /// <param name="name">指定 <see cref="User"/> 实例的名称</param>
        internal User(Session session, long number, string name) : base(session, number, name)
        {
        }
    }
}