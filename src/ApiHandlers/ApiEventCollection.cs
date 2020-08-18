using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    internal class ApiEventCollection
    {
        private Plugin Plugin { get; }

        public MessageEvent MessageEvent => new MessageEvent(Plugin);

        public async Task Listen()
        {
            await MessageEvent.ListenAsync();
        }

        public ApiEventCollection(Plugin plugin) => Plugin = plugin;
    }
}