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
            var messageData = JsonConvert.DeserializeObject<MessageData>(data);
            var member = await messageData.Sender.ToObject<MemberInfo>().GetMemberAsync(Session.CurrentUser);
            var parser = new GroupMessageParser(Session.CurrentUser, member.Group);
            var message = await GetMessage(parser, messageData.MessageChain);

            var e = new GroupMessageReceivedEventArgs(member, message);
            await InvokeAsync<CurrentUserEventSource>(x => x.OnGroupMessageReceived(Session, e));
        }

        /// <summary>
        /// 处理临时会话事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task MemberMessageEventHandling(string data)
        {
            var messageData = JsonConvert.DeserializeObject<MessageData>(data);
            var member = await messageData.Sender.ToObject<MemberInfo>().GetMemberAsync(Session.CurrentUser);
            var parser = new MemberMessageParser(Session.CurrentUser);
            var message = await GetMessage(parser, messageData.MessageChain);

            var e = new MemberMessageReceivedEventArgs(member, message);
            await InvokeAsync<CurrentUserEventSource>(x => x.OnMemberMessageReceived(Session, e));
        }

        /// <summary>
        /// 处理好友消息事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task FriendMessageEventHandling(string data)
        {
            var messageData = JsonConvert.DeserializeObject<MessageData>(data);
            var friend = await messageData.Sender.ToObject<FriendInfo>().GetFriendAsync(Session.CurrentUser);
            var parser = new FriendMessageParser(Session.CurrentUser);
            var message = await GetMessage(parser, messageData.MessageChain);

            var e = new FriendMessageReceivedEventArgs(friend, message);
            await InvokeAsync<CurrentUserEventSource>(x => x.OnFriendMessageReceived(Session, e));
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