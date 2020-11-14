using Newtonsoft.Json;
using System.Linq;

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
        /// 指定当前 <see cref="Quote"/> 实例的消息 ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        internal int MessageId => Message.Id;

        /// <summary>
        /// 指定当前 <see cref="Quote"/> 实例的群号码
        /// </summary>
        [JsonProperty(PropertyName = "groupId")]
        internal long GroupNumber => Sender is Member member ? member.Group.Number : 0;

        /// <summary>
        /// 指定当前 <see cref="Quote"/> 实例的发送者号码
        /// </summary>
        [JsonProperty(PropertyName = "senderId")]
        internal long SenderNumber => Sender.Number;

        /// <summary>
        /// 指定当前 <see cref="Quote"/> 实例的目标号码
        /// </summary>
        [JsonProperty(PropertyName = "targetId")]
        internal long TargetNumber => Target.Number;

        /// <summary>
        /// 指定当前 <see cref="Quote"/> 实例的消息链
        /// </summary>
        [JsonProperty(PropertyName = "origin")]
        internal MessageElement[] MessageChain => Message.FullContent.ToArray();

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
    }
}