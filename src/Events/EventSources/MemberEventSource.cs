using System.Threading.Tasks;

namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 指定成员事件源
    /// </summary>
    public class MemberEventSource : EventSource
    {
        /// <summary>
        /// 在收到临时会话消息时引发
        /// </summary>
        public event AsyncEventHandler<MemberMessageReceivedEventArgs> MemberMessageReceivedEvent;

        /// <summary>
        /// 触发 <see cref="MemberMessageReceivedEvent"/> 事件
        /// </summary>
        /// <param name="source">来源</param>
        /// <param name="message">消息</param>
        internal async Task OnMemberMessageReceived(Member source, Message message)
        {
            var e = new MemberMessageReceivedEventArgs(source, message);
            await InvokeAsync(MemberMessageReceivedEvent, e);
        }

        /// <summary>
        /// 创建 <see cref="MemberEventSource"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="MemberEventSource"/> 实例所使用的会话</param>
        internal MemberEventSource(Session session) : base(session)
        {
        }
    }
}