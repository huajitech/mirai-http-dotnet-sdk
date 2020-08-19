using System;

namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 为消息事件数据提供基类
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// 获取当前 <see cref="MessageEventArgs"/> 实例的来源
        /// </summary>
        public virtual Chat Source { get; }

        /// <summary>
        /// 获取当前 <see cref="MessageEventArgs"/> 实例的消息
        /// </summary>
        public virtual Message Message { get; }

        /// <summary>
        /// 创建 <see cref="MessageEventArgs"/> 实例
        /// </summary>
        /// <param name="source">指定 <see cref="MessageEventArgs"/> 实例的来源</param>
        /// <param name="message">指定 <see cref="MessageEventArgs"/> 实例的消息</param>
        public MessageEventArgs(Chat source, Message message)
        {
            Source = source;
            Message = message;
        }
    }
}