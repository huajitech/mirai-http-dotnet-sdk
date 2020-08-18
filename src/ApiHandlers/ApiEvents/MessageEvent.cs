using HuajiTech.Mirai.Extensions;
using HuajiTech.Mirai.Parsing;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    internal class MessageEvent : ApiEventHandler
    {
        protected override string Type { get; } = "message";

        protected override async Task EventHandlingAsync(string message)
        {
            var data = JObject.Parse(message);

            var task = _ = data.Value<string>("type") switch
            {
                "FriendMessage" => FriendMessageEventHandling(data),
                "GroupMessage" => GroupMessageEventHandling(data),
                "TempMessage" => MemberMessageEventHandling(data),
                _ => null
            };

            await task;
        }

        private async Task GroupMessageEventHandling(JObject data)
        {
            var member = GetMember((JObject)data["sender"]);
            var parser = new GroupMessageParser(Plugin.CurrentUser, member.Group);
            var message = await GetMessage(parser, (JArray)data["messageChain"]);
            await Plugin.MessageEventSource.OnMessageReceived(member.Group, member, message);
        }

        private async Task MemberMessageEventHandling(JObject data)
        {
            var member = GetMember((JObject)data["sender"]);
            var parser = new MemberMessageParser(Plugin.CurrentUser);
            var message = await GetMessage(parser, (JArray)data["messageChain"]);
            await Plugin.MessageEventSource.OnMessageReceived(member, member, message);
        }

        private async Task FriendMessageEventHandling(JObject data)
        {
            var friend = GetFriend((JObject)data["sender"]);
            var parser = new FriendMessageParser(Plugin.CurrentUser);
            var message = await GetMessage(parser, (JArray)data["messageChain"]);
            await Plugin.MessageEventSource.OnMessageReceived(friend, friend, message);
        }

        private async Task<Message> GetMessage(MessageParser parser, JArray messageChain)
        {
            var content = await Task.Run(() => parser.ParseMore(messageChain));
            return new Message(Plugin.Session, content.ToList());
        }

        private Friend GetFriend(JObject friend) => new Friend(Plugin.Session, friend.Value<long>("id"), friend.Value<string>("nickname"), friend.Value<string>("remark").CheckEmpty());

        private Group GetGroup(JObject group) => new Group(Plugin.Session, group.Value<long>("id"), group.Value<string>("name"));

        private Member GetMember(JObject sender) => new Member(GetGroup((JObject)sender["group"]), sender.Value<long>("id"), sender.Value<string>("memberName"), Member.MemberRoleDictionary[sender.Value<string>("permission")]);

        public MessageEvent(Plugin plugin) : base(plugin)
        {
        }
    }
}