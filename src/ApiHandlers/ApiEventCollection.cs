using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    internal class ApiEventCollection
    {
        private Plugin Plugin { get; }

        public MessageEvents MessageEvent => new MessageEvents(Plugin);

        public async Task Listen()
        {
            await MessageEvent.ListenAsync();
        }

        public ApiEventCollection(Plugin plugin) => Plugin = plugin;
    }
}