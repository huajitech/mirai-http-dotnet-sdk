using HuajiTech.Mirai.Events;

namespace HuajiTech.Mirai.Extensions
{
    public static class EventExtensions
    {
        public static void AddMessageReceivedEventHandler(this CurrentUserEventSource currentUserEventSource, AsyncEventHandler<MessageReceivedEventArgs> handler)
        {
            currentUserEventSource.FriendMessageReceivedEvent += new AsyncEventHandler<FriendMessageReceivedEventArgs>(handler);
            currentUserEventSource.GroupMessageReceivedEvent += new AsyncEventHandler<GroupMessageReceivedEventArgs>(handler);
            currentUserEventSource.MemberMessageReceivedEvent += new AsyncEventHandler<MemberMessageReceivedEventArgs>(handler);
        }
    }
}