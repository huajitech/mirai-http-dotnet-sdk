using HuajiTech.Mirai.Events;
using HuajiTech.Mirai.Interop;
using HuajiTech.Mirai.Parsing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    public partial class ApiEventHandler
    {
        /// <summary>
        /// 处理群消息事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task GroupMessageEventHandling(string data)
        {
            var info = JsonConvert.DeserializeObject<MessageData>(data);
            var senderInfo = info.Sender.ToObject<MemberSenderInfo>();
            var member = senderInfo.ToMember(Session.CurrentUser);
            var parser = new GroupMessageParser(Session.CurrentUser, member.Group);
            var message = await GetMessage(parser, info.MessageChain);

            await InvokeAsync<CurrentUserEventSource>(async x => await x.OnGroupMessageReceived(member, message));
            await InvokeAsync<CurrentUserEventSource>(async x => await x.OnMessageReceived(member.Group, member, message));
        }

        /// <summary>
        /// 处理临时会话事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task MemberMessageEventHandling(string data)
        {
            var info = JsonConvert.DeserializeObject<MessageData>(data);
            var senderInfo = info.Sender.ToObject<MemberSenderInfo>();
            var member = senderInfo.ToMember(Session.CurrentUser);
            var parser = new MemberMessageParser(Session.CurrentUser);
            var message = await GetMessage(parser, info.MessageChain);

            await InvokeAsync<CurrentUserEventSource>(async x => await x.OnMemberMessageReceived(member, message));
            await InvokeAsync<CurrentUserEventSource>(async x => await x.OnMessageReceived(member, member, message));
        }

        /// <summary>
        /// 处理好友消息事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task FriendMessageEventHandling(string data)
        {
            var info = JsonConvert.DeserializeObject<MessageData>(data);
            var senderInfo = info.Sender.ToObject<FriendSenderInfo>();
            var friend = senderInfo.ToFriend(Session);
            var parser = new FriendMessageParser(Session.CurrentUser);
            var message = await GetMessage(parser, info.MessageChain);

            await InvokeAsync<CurrentUserEventSource>(async x => await x.OnFriendMessageReceived(friend, message));
            await InvokeAsync<CurrentUserEventSource>(async x => await x.OnMessageReceived(friend, friend, message));
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
            return new Message(Session, content.ToList());
        }
    }
}