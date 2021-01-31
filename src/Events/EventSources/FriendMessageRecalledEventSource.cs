using HuajiTech.Mirai.Http.Interop.Events;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.Events
{
    /// <summary>
    /// 指定好友消息接收事件源
    /// </summary>
    public class FriendMessageRecalledEventSource : EventSource<MessageRecalledEventArgs>
    {
        /// <inheritdoc/>
        internal override string Type { get; } = "FriendRecallEvent";

        /// <inheritdoc/>
        private protected override async Task<MessageRecalledEventArgs> ToEventArgsAsync(string data, Session session)
        {
            var eventData = JsonConvert.DeserializeObject<FriendRecallEventData>(data);
            var @operator = await session.CurrentUser.GetUserAsync(eventData.Operator);
            var target = await session.CurrentUser.GetUserAsync(eventData.AuthorId);
            var message = await Message.TryGetMessageAsync(session.CurrentUser, eventData.MessageId);

            return new MessageRecalledEventArgs(@operator, target, message);
        }

        /// <summary>
        /// 创建 <see cref="FriendMessageRecalledEventSource"/> 实例
        /// </summary>
        public FriendMessageRecalledEventSource()
        {
        }
    }
}