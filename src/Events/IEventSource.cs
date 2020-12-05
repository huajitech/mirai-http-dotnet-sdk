using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.Events
{
    /// <summary>
    /// 定义事件源
    /// </summary>
    public interface IEventSource
    {
        /// <summary>
        /// 指定 <see cref="IEventSource"/> 对应的类型名称
        /// </summary>
        internal string Type { get; }

        /// <summary>
        /// 异步调用事件
        /// </summary>
        /// <param name="data">事件信息 Json</param>
        /// <param name="session">会话</param>
        internal Task InvokeAsync(string data, Session session);

        /// <summary>
        /// 移除所有 Handlers
        /// </summary>
        internal void RemoveAllHandlers();
    }
}