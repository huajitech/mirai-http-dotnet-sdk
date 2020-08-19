using System;

namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 为消息接收事件提供数据
    /// </summary>
    public class MessageReceivedEventArgs : MessageEventArgs
    {
        /// <summary>
        /// 获取当前 <see cref="MessageReceivedEventArgs"/> 实例的发送者
        /// </summary>
        public virtual User Sender { get; }

        /// <summary>
        /// 创建 <see cref="MessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="source">指定 <see cref="MessageReceivedEventArgs"/> 实例的来源</param>
        /// <param name="sender">指定 <see cref="MessageReceivedEventArgs"/> 实例的发送者</param>
        /// <param name="message">指定 <see cref="MessageReceivedEventArgs"/> 实例的消息</param>
        public MessageReceivedEventArgs(Chat source, User sender, Message message) : base(source, message) => Sender = sender;
    }
}