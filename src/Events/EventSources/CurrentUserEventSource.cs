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
        public event AsyncEventHandler<MessageReceivedEventArgs> MessageReceivedEvent;

        /// <summary>
        /// 在收到好友消息时引发
        /// </summary>
        public event AsyncEventHandler<FriendMessageReceivedEventArgs> FriendMessageReceivedEvent;

        /// <summary>
        /// 在收到群消息时引发
        /// </summary>
        public event AsyncEventHandler<MemberMessageReceivedEventArgs> GroupMessageReceivedEvent;

        /// <summary>
        /// 在收到临时会话消息时引发
        /// </summary>
        public event AsyncEventHandler<MemberMessageReceivedEventArgs> MemberMessageReceivedEvent;

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
        /// 触发 <see cref="FriendMessageReceivedEvent"/> 事件
        /// </summary>
        /// <param name="source">来源</param>
        /// <param name="message">消息</param>
        internal async Task OnFriendMessageReceived(Friend source, Message message)
        {
            var e = new FriendMessageReceivedEventArgs(source, message);
            await InvokeAsync(FriendMessageReceivedEvent, e);
        }

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
        /// 创建 <see cref="CurrentUserEventSource"/> 实例
        /// </summary>
        public CurrentUserEventSource()
        {
        }
    }
}