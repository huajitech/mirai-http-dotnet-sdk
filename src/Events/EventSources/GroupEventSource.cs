using System.Threading.Tasks;

namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 指定群事件源
    /// </summary>
    public class GroupEventSource : EventSource
    {
        /// <summary>
        /// 在收到群消息时引发
        /// </summary>
        public event AsyncEventHandler<MemberMessageReceivedEventArgs> GroupMessageReceivedEvent;

        /// <summary>
        /// 触发 <see cref="GroupMessageReceivedEvent"/> 事件
        /// </summary>
        /// <param name="source">来源</param>
        /// <param name="message">消息</param>
        internal async Task OnGroupMessageReceived(Member source, Message message)
        {
            var e = new MemberMessageReceivedEventArgs(source, message);
            await InvokeAsync(GroupMessageReceivedEvent, e);
        }

        /// <summary>
        /// 创建 <see cref="GroupEventSource"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="GroupEventSource"/> 实例所使用的会话</param>
        internal GroupEventSource(Session session) : base(session)
        {
        }
    }
}