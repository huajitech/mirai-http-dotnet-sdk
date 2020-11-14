using HuajiTech.Mirai.Events;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
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

        /// <summary>
        /// 添加消息撤回事件处理程序
        /// </summary>
        /// <param name="currentUserEventSource">当前用户事件源</param>
        /// <param name="handler">事件处理器</param>
        public static void AddMessageRecalledEventHandler(this CurrentUserEventSource currentUserEventSource, AsyncEventHandler<MessageRecalledEventArgs> handler)
        {
            currentUserEventSource.FriendMessageRecalledEvent += handler;
            currentUserEventSource.GroupMessageRecalledEvent += new AsyncEventHandler<GroupMessageRecalledEventArgs>(handler);
        }

        /// <summary>
        /// 回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <param name="isQuoting">是否引用回复</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> Reply(this MessageReceivedEventArgs e, ComplexMessage message, bool isQuoting = true)
        {
            var quote = isQuoting ? e.Message : null;

            if (e.Source is Group)
            {
                var member = e.Sender as Member;
                return e.Source.SendAsync(member.Mention() + message, quote);
            }
            else
            {
                return e.Source.SendAsync(message, quote);
            }
        }

        /// <summary>
        /// 回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <param name="isQuoting">是否引用回复</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> Reply(this MessageReceivedEventArgs e, MessageElement message, bool isQuoting = true) => e.Reply(ComplexMessage.Create(message), isQuoting);
    }
}