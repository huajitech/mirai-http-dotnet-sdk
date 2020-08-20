using System.Threading.Tasks;

namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 指定当前用户事件源
    /// </summary>
    public class CurrentUserEventSource : EventSource
    {
        /// <summary>
        /// 在收到消息时引发
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> MessageReceivedEvent;

        /// <summary>
        /// 触发 <see cref="MessageReceivedEvent"/> 事件
        /// </summary>
        /// <param name="source">来源</param>
        /// <param name="sender">发送者</param>
        /// <param name="message">消息</param>
        internal async Task OnMessageReceived(Chat source, User sender, Message message)
        {
            var e = new MessageReceivedEventArgs(source, sender, message);
            await InvokeAsync(MessageReceivedEvent, e);
        }

        /// <summary>
        /// 创建 <see cref="CurrentUserEventSource"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="CurrentUserEventSource"/> 实例所使用的会话</param>
        internal CurrentUserEventSource(Session session) : base(session)
        {
        }
    }
}