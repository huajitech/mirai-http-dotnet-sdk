namespace HuajiTech.Mirai
{
    /// <summary>
    /// 用作基于 Session 处理的基类
    /// </summary>
    public abstract class SessionProcessor
    {
        /// <summary>
        /// 获取当前 <see cref="SessionProcessor"/> 实例的 Session
        /// </summary>
        internal Session Session { get; } = null;

        /// <summary>
        /// 创建 <see cref="SessionProcessor"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="SessionProcessor"/> 实例所使用的 Session</param>
        internal SessionProcessor(Session session) => Session = session;
    }
}