using HuajiTech.Mirai.Http.Interop;
using HuajiTech.Mirai.Http.Parsing;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.Events
{
    /// <summary>
    /// 指定好友消息接收事件源
    /// </summary>
    public class FriendMessageReceivedEventSource : EventSource<FriendMessageReceivedEventArgs>
    {
        /// <inheritdoc/>
        internal override string Type { get; } = "FriendMessage";

        /// <inheritdoc/>
        private protected override async Task<FriendMessageReceivedEventArgs> ToEventArgsAsync(string data, Session session)
        {
            var messageData = JsonConvert.DeserializeObject<MessageData>(data);
            var friend = await messageData.Sender.ToObject<FriendInfo>().GetFriendAsync(session.CurrentUser);
            var parser = new FriendMessageParser(session.CurrentUser);
            var message = await Message.ToMessageAsync(session, parser, messageData.MessageChain);

            return new FriendMessageReceivedEventArgs(friend, message);
        }

        /// <summary>
        /// 创建 <see cref="FriendMessageReceivedEventSource"/> 实例
        /// </summary>
        public FriendMessageReceivedEventSource()
        {
        }
    }
}