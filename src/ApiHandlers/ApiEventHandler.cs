using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using WebSocketSharp;

namespace HuajiTech.Mirai.ApiHandlers
{
    /// <summary>
    /// 用作与 API 通过 Websocket 交互
    /// </summary>
    internal partial class ApiEventHandler
    {
        protected Plugin Plugin { get; }

        private async Task EventHandlingAsync(string message)
        {
            var data = JObject.Parse(message);

            var task = data.Value<string>("type") switch
            {
                "FriendMessage" => FriendMessageEventHandling(data),
                "GroupMessage" => GroupMessageEventHandling(data),
                "TempMessage" => MemberMessageEventHandling(data),
                _ => Task.Delay(0)
            };

            await task;
        }

        public async Task ListenAsync()
        {
            var server = new WebSocket(Plugin.Session.WebsocketUri + "all?sessionKey=" + Plugin.Session.SessionKey);
            server.OnMessage += (object sender, MessageEventArgs e) => EventHandlingAsync(e.Data).Wait();
            await Task.Run(() => server.Connect());
        }

        public ApiEventHandler(Plugin plugin) => Plugin = plugin;
    }
}