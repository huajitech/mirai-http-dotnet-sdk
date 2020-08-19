using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 指定好友事件源
    /// </summary>
    public class FriendEventSource : EventSource
    {
        /// <summary>
        /// 在收到好友消息时引发
        /// </summary>
        public event EventHandler<FriendMessageReceivedEventArgs> FriendMessageReceivedEvent;

        /// <summary>
        /// 触发 <see cref="FriendMessageReceivedEvent"/> 事件
        /// </summary>
        /// <param name="source">来源</param>
        /// <param name="message">消息</param>
        internal async Task OnFriendMessageReceived(Friend source, Message message)
        {
            var e = new FriendMessageReceivedEventArgs(source, message);
            await InvokeAsync(FriendMessageReceivedEvent, Session, e);
        }

        /// <summary>
        /// 创建 <see cref="FriendEventSource"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="FriendEventSource"/> 实例所使用的会话</param>
        internal FriendEventSource(Session session) : base(session)
        {
        }
    }
}