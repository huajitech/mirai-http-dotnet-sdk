using Newtonsoft.Json;

namespace HuajiTech.Mirai.Messaging
{
    /// <summary>
    /// 表示引用回复的 <see cref="MessageElement"/>
    /// </summary>
    public class Quote : MessageElement
    {
        internal override string Type { get; } = "Quote";

        /// <summary>
        /// 获取当前 <see cref="Quote"/> 实例的消息
        /// </summary>
        [JsonIgnore]
        public Message Message { get; }

        /// <summary>
        /// 获取当前 <see cref="Quote"/> 实例的发送者
        /// </summary>
        [JsonIgnore]
        public User Sender { get; }

        /// <summary>
        /// 获取当前 <see cref="Quote"/> 实例的发送目标
        /// </summary>
        [JsonIgnore]
        public Chat Target { get; }

        /// <summary>
        /// 创建 <see cref="Quote"/> 实例
        /// </summary>
        /// <param name="message">指定 <see cref="Quote"/> 实例的消息</param>
        /// <param name="sender">指定 <see cref="Quote"/> 实例的发送者</param>
        /// <param name="target">指定 <see cref="Quote"/> 实例的目标</param>
        internal Quote(Message message, User sender, Chat target)
        {
            Message = message;
            Sender = sender;
            Target = target;
        }

        /// <summary>
        /// 创建 <see cref="Quote"/> 实例
        /// </summary>
        /// <param name="message">指定 <see cref="Quote"/> 实例的消息</param>
        public Quote(Message message)
        {
            Message = message;
        }
    }
}