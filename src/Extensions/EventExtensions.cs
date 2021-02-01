using HuajiTech.Mirai.Http.Events;
using System;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 定义 <see cref="Events"/> 中的类型的扩展方法
    /// </summary>
    public static class EventExtensions
    {
        /// <summary>
        /// 回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> ReplyAsync(this MessageReceivedEventArgs e, ComplexMessage message) => e?.Source.SendAsync(GetReplyMessage(e, message ?? throw new ArgumentNullException(nameof(message)))) ?? throw new ArgumentNullException(nameof(e));

        /// <summary>
        /// 回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> ReplyAsync(this MessageReceivedEventArgs e, MessageElement message) => e.ReplyAsync(new ComplexMessage(message ?? throw new ArgumentNullException(nameof(message))));

        /// <summary>
        /// 引用回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> QuoteReplyAsync(this MessageReceivedEventArgs e, ComplexMessage message) => e?.Source.SendAsync(e.Message.Quote() + GetReplyMessage(e, message ?? throw new ArgumentNullException(nameof(message)))) ?? throw new ArgumentNullException(nameof(e));

        /// <summary>
        /// 引用回复当前 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> QuoteReplyAsync(this MessageReceivedEventArgs e, MessageElement message) => e.QuoteReplyAsync(new ComplexMessage(message ?? throw new ArgumentNullException(nameof(message)))) ?? throw new ArgumentNullException(nameof(e));

        /// <summary>
        /// 获取回复消息
        /// </summary>
        /// <param name="e">指定 <see cref="MessageReceivedEventArgs"/> 实例</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        private static ComplexMessage GetReplyMessage(MessageReceivedEventArgs e, ComplexMessage message) => (e?.Source ?? throw new ArgumentNullException(nameof(e))) is Group ? (e.Sender as Member).Mention() + message : message;
    }
}