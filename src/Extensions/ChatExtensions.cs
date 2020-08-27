using HuajiTech.Mirai.Messaging;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Extensions
{
    /// <summary>
    /// 定义 <see cref="Chat"/> 类型的扩展方法
    /// </summary>
    public static class ChatExtensions
    {
        /// <summary>
        /// 异步发送消息到当前 <see cref="Chat"/> 实例
        /// </summary>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> SendAsync(this Chat chat, Message message) => chat.SendAsync(message.Content);

        /// <summary>
        /// 异步发送消息到当前 <see cref="Chat"/> 实例
        /// </summary>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> SendAsync(this Chat chat, string message) => chat.SendAsync(new MessageElement[] { new PlainText(message) });

        /// <summary>
        /// 异步发送消息到当前 <see cref="Chat"/> 实例
        /// </summary>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> SendAsync(this Chat chat, MessageElement message) => chat.SendAsync(new MessageElement[] { message });
    }
}