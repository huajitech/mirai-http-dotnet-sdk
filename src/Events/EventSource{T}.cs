using System;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.Events
{
    /// <summary>
    /// 定义事件源
    /// </summary>
    /// <typeparam name="TEventArgs">事件数据类型</typeparam>
    public abstract class EventSource<TEventArgs> : IEventSource
        where TEventArgs : EventArgs
    {
        /// <summary>
        /// 在当前事件响应时引发
        /// </summary>
        public event AsyncEventHandler<TEventArgs> Event;

        /// <summary>
        /// 指定 <see cref="EventSource{T}"/> 对应的类型名称
        /// </summary>
        internal abstract string Type { get; }

        /// <inheritdoc/>
        string IEventSource.Type => Type;

        /// <inheritdoc/>
        async Task IEventSource.InvokeAsync(string data, Session session) => await InvokeAsync(Event, session, await ToEventArgsAsync(data, session));

        /// <summary>
        /// 将事件信息 Json 转换为 <typeparamref name="TEventArgs"/> 实例
        /// </summary>
        /// <param name="data">事件信息 Json</param>
        /// <param name="session">会话</param>
        private protected abstract Task<TEventArgs> ToEventArgsAsync(string data, Session session);

        /// <summary>
        /// 异步调用事件
        /// </summary>
        /// <param name="handlers">事件处理器</param>
        /// <param name="session">会话</param>
        /// <param name="e">事件数据</param>
        private static async Task InvokeAsync(AsyncEventHandler<TEventArgs> handlers, Session session, TEventArgs e)
        {
            if (handlers != null)
            {
                await handlers.Invoke(session, e);
            }
        }

        /// <inheritdoc/>
        void IEventSource.RemoveAllHandlers()
        {
            foreach (var eventField in GetType().GetEvents().Select(x => GetType().GetField(x.Name)))
            {
                eventField?.SetValue(this, null);
            }
        }

        /// <summary>
        /// 创建 <see cref="EventSource{T}"/> 实例
        /// </summary>
        public EventSource()
        {
        }
    }
}