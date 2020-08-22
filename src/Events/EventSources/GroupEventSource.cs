namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 指定群事件源
    /// </summary>
    public class GroupEventSource : EventSource
    {
        /// <summary>
        /// 创建 <see cref="GroupEventSource"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="GroupEventSource"/> 实例所使用的会话</param>
        internal GroupEventSource(Session session) : base(session)
        {
        }
    }
}