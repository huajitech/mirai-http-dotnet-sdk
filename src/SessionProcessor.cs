namespace HuajiTech.Mirai
{
    /// <summary>
    /// 用作基于 Session 处理的基类
    /// </summary>
    public class SessionProcessor
    {
        /// <summary>
        /// 获取当前 <see cref="SessionProcessor"/> 实例的 Session
        /// </summary>
        internal Session Session { get; private set; } = null;

        /// <summary>
        /// 设置当前 <see cref="SessionProcessor"/> 实例的 Session
        /// </summary>
        /// <param name="session"></param>
        internal void SetSession(Session session) => Session = session;

        /// <summary>
        /// 创建 <see cref="SessionProcessor"/> 实例
        /// </summary>
        internal SessionProcessor()
        {
        }

        /// <summary>
        /// 创建 <see cref="SessionProcessor"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="SessionProcessor"/> 实例所使用的 Session</param>
        internal SessionProcessor(Session session) => Session = session;
    }
}