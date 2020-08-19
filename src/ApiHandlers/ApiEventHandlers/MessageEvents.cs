using HuajiTech.Mirai.Extensions;
using HuajiTech.Mirai.Parsing;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    internal partial class ApiEventHandler
    {
        /// <summary>
        /// 处理群消息事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task GroupMessageEventHandling(JObject data)
        {
            var member = GetMember((JObject)data["sender"]);
            var parser = new GroupMessageParser(Plugin.CurrentUser, member.Group);
            var message = await GetMessage(parser, (JArray)data["messageChain"]);
            await Plugin.GroupEventSource.OnGroupMessageReceived(member, message);
            await Plugin.CurrentUserEventSource.OnMessageReceived(member.Group, member, message);
        }

        /// <summary>
        /// 处理临时会话事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task MemberMessageEventHandling(JObject data)
        {
            var member = GetMember((JObject)data["sender"]);
            var parser = new MemberMessageParser(Plugin.CurrentUser);
            var message = await GetMessage(parser, (JArray)data["messageChain"]);
            await Plugin.MemberEventSource.OnMemberMessageReceived(member, message);
            await Plugin.CurrentUserEventSource.OnMessageReceived(member, member, message);
        }

        /// <summary>
        /// 处理好友消息事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task FriendMessageEventHandling(JObject data)
        {
            var friend = GetFriend((JObject)data["sender"]);
            var parser = new FriendMessageParser(Plugin.CurrentUser);
            var message = await GetMessage(parser, (JArray)data["messageChain"]);
            await Plugin.FriendEventSource.OnFriendMessageReceived(friend, message);
            await Plugin.CurrentUserEventSource.OnMessageReceived(friend, friend, message);
        }

        /// <summary>
        /// 从 Json 消息链中提取信息，并创建 <see cref="Message"/> 实例
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="messageChain"></param>
        /// <returns></returns>
        private async Task<Message> GetMessage(MessageParser parser, JArray messageChain)
        {
            var content = await Task.Run(() => parser.ParseMore(messageChain));
            return new Message(Plugin.Session, content.ToList());
        }

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Friend"/> 实例
        /// </summary>
        /// <param name="friend">以 Json 表达的好友</param>
        private Friend GetFriend(JObject friend) => new Friend(Plugin.Session, friend.Value<long>("id"), friend.Value<string>("nickname"), friend.Value<string>("remark").CheckEmpty());

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Group"/> 实例
        /// </summary>
        /// <param name="group">以 Json 表达的群</param>
        private Group GetGroup(JObject group) => new Group(Plugin.Session, group.Value<long>("id"), group.Value<string>("name"));

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Member"/> 实例
        /// </summary>
        /// <param name="sender">以 Json 表达的发送者</param>
        private Member GetMember(JObject sender) => new Member(GetGroup((JObject)sender["group"]), sender.Value<long>("id"), sender.Value<string>("memberName"), Member.MemberRoleDictionary[sender.Value<string>("permission")]);
    }
}