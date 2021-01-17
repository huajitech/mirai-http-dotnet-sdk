using HuajiTech.Mirai.Http.Interop.Events;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.Events
{
    /// <summary>
    /// 指定好友消息接收事件源
    /// </summary>
    public class GroupMessageRecalledEventSource : EventSource<GroupMessageRecalledEventArgs>
    {
        /// <inheritdoc/>
        internal override string Type { get; } = "GroupRecallEvent";

        /// <inheritdoc/>
        private protected override async Task<GroupMessageRecalledEventArgs> ToEventArgsAsync(string data, Session session)
        {
            var eventData = JsonConvert.DeserializeObject<GroupRecallEventData>(data);
            var group = await eventData.Group.GetGroupAsync(session.CurrentUser);
            var @operator = eventData.Operator == null ? group.CurrentUser : await eventData.Operator.GetMemberAsync(session.CurrentUser);
            var target = await group.GetMemberAsync(eventData.AuthorId);
            var message = await Message.TryGetMessageAsync(session.CurrentUser, eventData.MessageId);

            return new(@operator, target, message);
        }

        /// <summary>
        /// 创建 <see cref="GroupMessageRecalledEventSource"/> 实例
        /// </summary>
        public GroupMessageRecalledEventSource()
        {
        }
    }
}