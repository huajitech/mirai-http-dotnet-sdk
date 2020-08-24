using System.Threading.Tasks;

namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 指定当前用户事件源
    /// </summary>
    public class CurrentUserEventSource : EventSource
    {
        /// <summary>
        /// 在收到好友消息时引发
        /// </summary>
        public event AsyncEventHandler<FriendMessageReceivedEventArgs> FriendMessageReceivedEvent;

        /// <summary>
        /// 在收到群消息时引发
        /// </summary>
        public event AsyncEventHandler<GroupMessageReceivedEventArgs> GroupMessageReceivedEvent;

        /// <summary>
        /// 在收到临时会话消息时引发
        /// </summary>
        public event AsyncEventHandler<MemberMessageReceivedEventArgs> MemberMessageReceivedEvent;

        /// <summary>
        /// 触发 <see cref="FriendMessageReceivedEvent"/> 事件
        /// </summary>
        /// <param name="e"><see cref="FriendMessageReceivedEventArgs"/> 实例</param>
        internal async Task OnFriendMessageReceived(Session session, FriendMessageReceivedEventArgs e) => await InvokeAsync(FriendMessageReceivedEvent, session, e);

        /// <summary>
        /// 触发 <see cref="GroupMessageReceivedEvent"/> 事件
        /// </summary>
        /// <param name="e"><see cref="GroupMessageReceivedEventArgs"/> 实例</param>
        internal async Task OnGroupMessageReceived(Session session, GroupMessageReceivedEventArgs e) => await InvokeAsync(GroupMessageReceivedEvent, session, e);

        /// <summary>
        /// 触发 <see cref="MemberMessageReceivedEvent"/> 事件
        /// </summary>
        /// <param name="e"><see cref="MemberMessageReceivedEventArgs"/> 实例</param>
        internal async Task OnMemberMessageReceived(Session session, MemberMessageReceivedEventArgs e) => await InvokeAsync(MemberMessageReceivedEvent, session, e);

        /// <summary>
        /// 创建 <see cref="CurrentUserEventSource"/> 实例
        /// </summary>
        public CurrentUserEventSource()
        {
        }
    }
}