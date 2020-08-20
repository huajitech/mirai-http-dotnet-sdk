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
        /// <summary>
        /// 获取当前 <see cref="ApiEventHandler"/> 的插件
        /// </summary>
        protected Plugin Plugin { get; }

        /// <summary>
        /// 异步处理通过 Websocket 获取的消息
        /// </summary>
        /// <param name="message">通过 Websocket 获取的消息</param>
        private async Task EventHandlingAsync(string message)
        {
            var data = JObject.Parse(message);

            var task = data.Value<string>("type") switch
            {
                "FriendMessage" => FriendMessageEventHandling(data),
                "GroupMessage" => GroupMessageEventHandling(data),
                "TempMessage" => MemberMessageEventHandling(data),
                "BotOnlineEvent" => BotOnlineEvent(data),
                "BotReloginEvent" => BotReloginEvent(data),
                _ => Task.Delay(0)
            };

            await task;
        }

        /// <summary>
        /// 异步监听 Websocket
        /// </summary>
        public async Task ListenAsync()
        {
            var server = new WebSocket(Plugin.Session.WebsocketUri + "all?sessionKey=" + Plugin.Session.SessionKey);
            server.OnMessage += (object sender, MessageEventArgs e) => EventHandlingAsync(e.Data).Wait();
            await Task.Run(server.Connect);
        }

        /// <summary>
        /// 创建 <see cref="ApiEventHandler"/> 实例
        /// </summary>
        /// <param name="plugin">指定 <see cref="ApiEventHandler"/> 实例所使用的插件</param>
        public ApiEventHandler(Plugin plugin) => Plugin = plugin;
    }
}