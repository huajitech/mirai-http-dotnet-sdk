using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public abstract class Chat : SessionProcessor
    {
        public long Number { get; protected set; }

        internal abstract Task<string> InternalSendAsync(MessageElement[] message);

        public async Task<Message> SendAsync(List<MessageElement> message)
        {
            var result = JObject.Parse(await InternalSendAsync(message.ToArray())).CheckError();
            return new Message(result.Value<int>("messageId"), message, CurrentSession);
        }

        public async Task<Message> SendAsync(MessageElement[] message)
        {
            var result = JObject.Parse(await InternalSendAsync(message)).CheckError();
            return new Message(result.Value<int>("messageId"), message.ToList(), CurrentSession);
        }

        public async Task<Message> SendAsync(string message) => await SendAsync(new MessageElement[] { new PlainText(message) });

        public async Task<Message> SendAsync(MessageElement message) => await SendAsync(new MessageElement[] { message });

        public async Task<Message> SendAsync(PlainText message) => await SendAsync((MessageElement)message);

        public Chat(Session session) : base(session)
        {
        }
    }
}