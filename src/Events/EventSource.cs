using System;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 定义事件源
    /// </summary>
    public class EventSource
    {
        /// <summary>
        /// 异步调用事件
        /// </summary>
        /// <typeparam name="TEventArgs">事件数据类型</typeparam>
        /// <param name="handlers">事件处理器</param>
        /// <param name="session">会话</param>
        /// <param name="e">事件数据</param>
        internal static async Task InvokeAsync<TEventArgs>(AsyncEventHandler<TEventArgs> handlers, Session session, TEventArgs e)
            where TEventArgs : EventArgs
        {
            if (handlers != null)
            {
                await handlers.Invoke(session, e);
            }
        }

        /// <summary>
        /// 移除所有 Handlers
        /// </summary>
        internal void RemoveAllHandlers()
        {
            foreach (var eventField in GetType().GetEvents().Select(x => GetType().GetField(x.Name)))
            {
                eventField?.SetValue(this, null);
            }
        }

        /// <summary>
        /// 创建 <see cref="EventSource"/> 实例
        /// </summary>
        public EventSource()
        {
        }
    }
}