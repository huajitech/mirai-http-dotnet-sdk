using HuajiTech.Mirai.Events;
using HuajiTech.Mirai.Interop.Events;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    public partial class ApiEventHandler
    {
        /// <summary>
        /// 处理群消息撤回事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task GroupRecallEventHandling(string data)
        {
            var eventData = JsonConvert.DeserializeObject<GroupRecallEventData>(data);
            var group = await eventData.Group.GetGroupAsync(Session.CurrentUser);
            var @operator = eventData.Operator == null ? group.CurrentUser : await eventData.Operator.GetMemberAsync(Session.CurrentUser);
            var target = await group.GetMemberAsync(eventData.AuthorId);
            var message = await Message.TryGetMessageAsync(Session.CurrentUser, eventData.MessageId);

            var e = new GroupMessageRecalledEventArgs(@operator, target, message);
            await InvokeAsync<CurrentUserEventSource>(x => x.OnGroupMessageRecalled(Session, e));
        }

        /// <summary>
        /// 处理好友消息撤回事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task FriendRecallEventHandling(string data)
        {
            var eventData = JsonConvert.DeserializeObject<FriendRecallEventData>(data);
            var @operator = await Session.CurrentUser.GetUserAsync(eventData.Operator);
            var target = await Session.CurrentUser.GetUserAsync(eventData.AuthorId);
            var message = await Message.TryGetMessageAsync(Session.CurrentUser, eventData.MessageId);

            var e = new MessageRecalledEventArgs(@operator, target, message);
            await InvokeAsync<CurrentUserEventSource>(x => x.OnFriendMessageRecalled(Session, e));
        }
    }
}