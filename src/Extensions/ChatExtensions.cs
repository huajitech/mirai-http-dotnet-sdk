using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 定义 <see cref="Chat"/> 类型的扩展方法
    /// </summary>
    public static class ChatExtensions
    {
        /// <summary>
        /// 异步发送消息到当前 <see cref="Chat"/> 实例
        /// </summary>
        /// <param name="chat">目标聊天</param>
        /// <param name="message">要发送的消息</param>
        /// <returns>所发送消息的 <see cref="Message"/> 实例</returns>
        public static Task<Message> SendAsync(this Chat chat, MessageElement message) => chat.SendAsync(ComplexMessage.Create(message));
    }
}