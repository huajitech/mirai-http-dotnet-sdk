using HuajiTech.Mirai.Interop;
using HuajiTech.Mirai.Parsing;
using Newtonsoft.Json;
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
        private async Task GroupMessageEventHandling(string data)
        {
            var info = JsonConvert.DeserializeObject<MessageData>(data);
            var senderInfo = info.Sender.ToObject<MemberSenderInfo>();
            var member = senderInfo.ToMember(Plugin.CurrentUser);
            var parser = new GroupMessageParser(Plugin.CurrentUser, member.Group);
            var message = await GetMessage(parser, info.MessageChain);

            await Plugin.CurrentUserEventSource.OnGroupMessageReceived(member, message);
            await Plugin.CurrentUserEventSource.OnMessageReceived(member.Group, member, message);
        }

        /// <summary>
        /// 处理临时会话事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task MemberMessageEventHandling(string data)
        {
            var info = JsonConvert.DeserializeObject<MessageData>(data);
            var senderInfo = info.Sender.ToObject<MemberSenderInfo>();
            var member = senderInfo.ToMember(Plugin.CurrentUser);
            var parser = new MemberMessageParser(Plugin.CurrentUser);
            var message = await GetMessage(parser, info.MessageChain);

            await Plugin.CurrentUserEventSource.OnMemberMessageReceived(member, message);
            await Plugin.CurrentUserEventSource.OnMessageReceived(member, member, message);
        }

        /// <summary>
        /// 处理好友消息事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task FriendMessageEventHandling(string data)
        {
            var info = JsonConvert.DeserializeObject<MessageData>(data);
            var senderInfo = info.Sender.ToObject<FriendSenderInfo>();
            var friend = senderInfo.ToFriend(Plugin.Session);
            var parser = new FriendMessageParser(Plugin.CurrentUser);
            var message = await GetMessage(parser, info.MessageChain);

            await Plugin.CurrentUserEventSource.OnFriendMessageReceived(friend, message);
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
    }
}