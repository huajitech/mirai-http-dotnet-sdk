using HuajiTech.Mirai.Events;
using HuajiTech.Mirai.Messaging;
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
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> Reply(this MessageReceivedEventArgs e, ComplexMessage message) => e.Source.SendAsync(GetReplyMessage(e, message));

        /// <summary>
        /// 回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> Reply(this MessageReceivedEventArgs e, MessageElement message) => e.Reply(ComplexMessage.Create(message));

        /// <summary>
        /// 引用回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> QuoteReply(this MessageReceivedEventArgs e, ComplexMessage message) => e.Source.SendAsync(e.Message.Quote() + GetReplyMessage(e, message));

        /// <summary>
        /// 引用回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> QuoteReply(this MessageReceivedEventArgs e, MessageElement message) => e.QuoteReply(ComplexMessage.Create(message));

        /// <summary>
        /// 获取回复消息
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        private static ComplexMessage GetReplyMessage(MessageReceivedEventArgs e, ComplexMessage message) => e.Source is Group ? (e.Sender as Member).Mention() + message : message;
    }
}