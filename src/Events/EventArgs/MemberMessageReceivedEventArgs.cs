using System;
using System.Collections.Generic;
using System.Text;

namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 为群消息和临时会话接收事件提供数据
    /// </summary>
    public class MemberMessageReceivedEventArgs : MessageEventArgs
    {
        /// <summary>
        /// 获取当前 <see cref="MemberMessageReceivedEventArgs"/> 实例的来源
        /// </summary>
        public new virtual Member Source { get; }

        /// <summary>
        /// 创建 <see cref="MemberMessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="source">指定 <see cref="MemberMessageReceivedEventArgs"/> 实例的来源</param>
        /// <param name="message">指定 <see cref="MemberMessageReceivedEventArgs"/> 实例的消息</param>
        public MemberMessageReceivedEventArgs(Member source, Message message) : base(source, message) => Source = source;
    }
}