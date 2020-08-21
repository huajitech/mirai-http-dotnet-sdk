using HuajiTech.Mirai.Messaging;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Extensions
{
    public static class ChatExtensions
    {
        /// <summary>
        /// 异步发送消息到当前 <see cref="Chat"/> 实例
        /// </summary>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static async Task<Message> SendAsync(this Chat chat, Message message) => await chat.SendAsync(message.Content);

        /// <summary>
        /// 异步发送消息到当前 <see cref="Chat"/> 实例
        /// </summary>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static async Task<Message> SendAsync(this Chat chat, string message) => await chat.SendAsync(new MessageElement[] { new PlainText(message) });

        /// <summary>
        /// 异步发送消息到当前 <see cref="Chat"/> 实例
        /// </summary>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static async Task<Message> SendAsync(this Chat chat, MessageElement message) => await chat.SendAsync(new MessageElement[] { message });
    }
}