using HuajiTech.Mirai.Http.Events;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http
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
            currentUserEventSource.FriendMessageReceivedEvent += new(handler);
            currentUserEventSource.GroupMessageReceivedEvent += new(handler);
            currentUserEventSource.MemberMessageReceivedEvent += new(handler);
        }

        /// <summary>
        /// 添加消息撤回事件处理程序
        /// </summary>
        /// <param name="currentUserEventSource">当前用户事件源</param>
        /// <param name="handler">事件处理器</param>
        public static void AddMessageRecalledEventHandler(this CurrentUserEventSource currentUserEventSource, AsyncEventHandler<MessageRecalledEventArgs> handler)
        {
            currentUserEventSource.FriendMessageRecalledEvent += handler;
            currentUserEventSource.GroupMessageRecalledEvent += new(handler);
        }

        /// <summary>
        /// 回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> ReplyAsync(this MessageReceivedEventArgs e, ComplexMessage message) => e.Source.SendAsync(GetReplyMessage(e, message));

        /// <summary>
        /// 回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> ReplyAsync(this MessageReceivedEventArgs e, MessageElement message) => e.ReplyAsync(ComplexMessage.Create(message));

        /// <summary>
        /// 引用回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> QuoteReplyAsync(this MessageReceivedEventArgs e, ComplexMessage message) => e.Source.SendAsync(e.Message.Quote() + GetReplyMessage(e, message));

        /// <summary>
        /// 引用回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> QuoteReplyAsync(this MessageReceivedEventArgs e, MessageElement message) => e.QuoteReplyAsync(ComplexMessage.Create(message));

        /// <summary>
        /// 获取回复消息
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        private static ComplexMessage GetReplyMessage(MessageReceivedEventArgs e, ComplexMessage message) => e.Source is Group ? (e.Sender as Member).Mention() + message : message;
    }
}