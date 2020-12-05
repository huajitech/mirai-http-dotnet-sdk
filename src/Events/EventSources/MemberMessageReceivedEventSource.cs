using HuajiTech.Mirai.Http.Interop;
using HuajiTech.Mirai.Http.Parsing;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.Events
{
    /// <summary>
    /// 指定好友消息接收事件源
    /// </summary>
    public class MemberMessageReceivedEventSource : EventSource<MemberMessageReceivedEventArgs>
    {
        /// <inheritdoc/>
        internal override string Type { get; } = "MemberMessage";

        /// <inheritdoc/>
        private protected override async Task<MemberMessageReceivedEventArgs> ToEventArgsAsync(string data, Session session)
        {
            var messageData = JsonConvert.DeserializeObject<MessageData>(data);
            var member = await messageData.Sender.ToObject<MemberInfo>().GetMemberAsync(session.CurrentUser);
            var parser = new MemberMessageParser(session.CurrentUser);
            var message = await Message.ToMessageAsync(session, parser, messageData.MessageChain);

            return new(member, message);
        }
    }
}