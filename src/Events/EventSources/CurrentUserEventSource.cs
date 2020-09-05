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
        /// 在群消息撤回时引发
        /// </summary>
        public event AsyncEventHandler<GroupMessageRecalledEventArgs> GroupMessageRecalledEvent;

        /// <summary>
        /// 在好友消息撤回时引发
        /// </summary>
        public event AsyncEventHandler<MessageRecalledEventArgs> FriendMessageRecalledEvent;

        /// <summary>
        /// 触发 <see cref="FriendMessageReceivedEvent"/> 事件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="e"><see cref="FriendMessageReceivedEventArgs"/> 实例</param>
        internal Task OnFriendMessageReceived(Session session, FriendMessageReceivedEventArgs e) => InvokeAsync(FriendMessageReceivedEvent, session, e);

        /// <summary>
        /// 触发 <see cref="GroupMessageReceivedEvent"/> 事件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="e"><see cref="GroupMessageReceivedEventArgs"/> 实例</param>
        internal Task OnGroupMessageReceived(Session session, GroupMessageReceivedEventArgs e) => InvokeAsync(GroupMessageReceivedEvent, session, e);

        /// <summary>
        /// 触发 <see cref="MemberMessageReceivedEvent"/> 事件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="e"><see cref="MemberMessageReceivedEventArgs"/> 实例</param>
        internal Task OnMemberMessageReceived(Session session, MemberMessageReceivedEventArgs e) => InvokeAsync(MemberMessageReceivedEvent, session, e);

        /// <summary>
        /// 触发 <see cref="GroupMessageRecalledEvent"/> 事件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="e"><see cref="GroupMessageRecalledEventArgs"/> 实例</param>
        internal Task OnGroupMessageRecalled(Session session, GroupMessageRecalledEventArgs e) => InvokeAsync(GroupMessageRecalledEvent, session, e);

        /// <summary>
        /// 触发 <see cref="FriendMessageRecalledEvent"/> 事件
        /// </summary>
        /// <param name="session">会话</param>
        /// <param name="e"><see cref="MessageRecalledEventArgs"/> 实例</param>
        internal Task OnFriendMessageRecalled(Session session, MessageRecalledEventArgs e) => InvokeAsync(FriendMessageRecalledEvent, session, e);

        /// <summary>
        /// 创建 <see cref="CurrentUserEventSource"/> 实例
        /// </summary>
        public CurrentUserEventSource()
        {
        }
    }
}