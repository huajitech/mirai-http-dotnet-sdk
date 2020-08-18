using System.Threading.Tasks;
using WebSocketSharp;

namespace HuajiTech.Mirai.ApiHandlers
{
    /// <summary>
    /// 提供与 API 通过 Websocket 交互的方法
    /// </summary>
    internal abstract class ApiEventHandler
    {
        protected abstract string Type { get; }

        protected abstract Task EventHandlingAsync(string message);

        protected Plugin Plugin { get; }

        public async Task ListenAsync()
        {
            var server = new WebSocket(Plugin.Session.Settings.WebsocketUri + Type + "?sessionKey=" + Plugin.Session.SessionKey);
            server.OnMessage += (object sender, MessageEventArgs e) => EventHandlingAsync(e.Data).Wait();
            await Task.Run(() => server.Connect());
        }

        public ApiEventHandler(Plugin plugin) => Plugin = plugin;
    }
}