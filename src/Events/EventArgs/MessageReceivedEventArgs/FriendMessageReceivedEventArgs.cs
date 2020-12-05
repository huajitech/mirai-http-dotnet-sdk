namespace HuajiTech.Mirai.Http.Events
{
    /// <summary>
    /// 为好友消息接收事件提供数据
    /// </summary>
    public class FriendMessageReceivedEventArgs : MessageReceivedEventArgs
    {
        /// <summary>
        /// 获取当前 <see cref="FriendMessageReceivedEventArgs"/> 实例的来源
        /// </summary>
        public new virtual Friend Source { get; }

        /// <summary>
        /// 获取当前 <see cref="FriendMessageReceivedEventArgs"/> 实例的发送者
        /// </summary>
        public new virtual Friend Sender => Source;

        /// <summary>
        /// 创建 <see cref="FriendMessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="source">指定 <see cref="FriendMessageReceivedEventArgs"/> 实例的来源</param>
        /// <param name="message">指定 <see cref="FriendMessageReceivedEventArgs"/> 实例的消息</param>
        public FriendMessageReceivedEventArgs(Friend source, Message message) : base(source, source, message) => Source = source;
    }
}