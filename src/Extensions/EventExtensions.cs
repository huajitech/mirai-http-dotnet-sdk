using HuajiTech.Mirai.Events;

namespace HuajiTech.Mirai.Extensions
{
    /// <summary>
    /// 定义 <see cref="Events"/> 中的类型的扩展方法
    /// </summary>
    public static class EventExtensions
    {
        /// <summary>
        /// 添加消息接收事件处理程序
        /// </summary>
        /// <param name="currentUserEventSource">当前用户事件源</param>
        /// <param name="handler">事件处理器</param>
        public static void AddMessageReceivedEventHandler(this CurrentUserEventSource currentUserEventSource, AsyncEventHandler<MessageReceivedEventArgs> handler)
        {
            currentUserEventSource.FriendMessageReceivedEvent += new AsyncEventHandler<FriendMessageReceivedEventArgs>(handler);
            currentUserEventSource.GroupMessageReceivedEvent += new AsyncEventHandler<GroupMessageReceivedEventArgs>(handler);
            currentUserEventSource.MemberMessageReceivedEvent += new AsyncEventHandler<MemberMessageReceivedEventArgs>(handler);
        }
    }
}