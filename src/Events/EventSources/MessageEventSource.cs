using System.Threading.Tasks;

namespace HuajiTech.Mirai.Events
{
    public class MessageEventSource : EventSource
    {
        public event EventHandler<MessageReceviedEventArgs> MessageReceivedEvent;

        internal async Task OnMessageReceived(Chat source, User sender, Message message)
        {
            var e = new MessageReceviedEventArgs(source, sender, message);
            await InvokeAsync(MessageReceivedEvent, Session, e);
        }

        internal MessageEventSource(Session session) : base(session)
        {
        }
    }
}