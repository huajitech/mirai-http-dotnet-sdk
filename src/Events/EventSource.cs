using System.Threading.Tasks;

namespace HuajiTech.Mirai.Events
{
    public class EventSource : SessionProcessor
    {
        internal static async Task InvokeAsync<TEventArgs>(EventHandler<TEventArgs> handlers, Session sender, TEventArgs e)
        {
            if (handlers != null)
            {
                await handlers.Invoke(sender, e);
            }
        }

        internal EventSource(Session session) : base(session)
        {
        }
    }
}