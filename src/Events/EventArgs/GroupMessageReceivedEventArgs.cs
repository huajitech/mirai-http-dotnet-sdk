namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 为群消息和临时会话接收事件提供数据
    /// </summary>
    public class GroupMessageReceivedEventArgs : MessageReceivedEventArgs
    {
        /// <summary>
        /// 获取当前 <see cref="MemberMessageReceivedEventArgs"/> 实例的来源
        /// </summary>
        public new virtual Group Source => Sender.Group;

        /// <summary>
        /// 获取当前 <see cref="MemberMessageReceivedEventArgs"/> 实例的发送者
        /// </summary>
        public new virtual Member Sender { get; }

        /// <summary>
        /// 创建 <see cref="MemberMessageReceivedEventArgs"/> 实例
        /// </summary>
        /// <param name="sender">指定 <see cref="MemberMessageReceivedEventArgs"/> 实例的发送者</param>
        /// <param name="message">指定 <see cref="MemberMessageReceivedEventArgs"/> 实例的消息</param>
        public GroupMessageReceivedEventArgs(Member sender, Message message) : base(sender.Group, sender, message) => Sender = sender;
    }
}