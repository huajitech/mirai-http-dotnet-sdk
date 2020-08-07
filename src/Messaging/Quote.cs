using Newtonsoft.Json;

namespace HuajiTech.Mirai.Messaging
{
    public class Quote : MessageElement
    {
        internal override string Type { get; } = "Quote";

        [JsonIgnore]
        public Message Message { get; }

        [JsonIgnore]
        public User Sender { get; }

        [JsonIgnore]
        public Chat Target { get; }

        [JsonProperty(PropertyName = "id")]
        internal int MessageId => Message.Id;

        [JsonProperty(PropertyName = "groupId")]
        internal long GroupNumber => Sender is Member member ? member.Group.Number : 0;

        [JsonProperty(PropertyName = "senderId")]
        internal long SenderNumber => Sender.Number;

        [JsonProperty(PropertyName = "targetId")]
        internal long TargetNumber => Target.Number;

        [JsonProperty(PropertyName = "origin")]
        internal MessageElement[] MessageChain => Message.FullContent.ToArray();

        public Quote(Message message, User sender, Chat target)
        {
            Message = message;
            Sender = sender;
            Target = target;
        }
    }
}