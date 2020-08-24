using HuajiTech.Mirai.Events;
using HuajiTech.Mirai.Interop;
using Newtonsoft.Json;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using WebSocketSharp;

namespace HuajiTech.Mirai.ApiHandlers
{
    /// <summary>
    /// 用作与 API 通过 Websocket 交互
    /// </summary>
    public partial class ApiEventHandler : SessionProcessor, IAsyncDisposable
    {
        /// <summary>
        /// 当前 <see cref="ApiEventHandler"/> 的 <see cref="WebSocket"/> 实例
        /// </summary>
        private WebSocket Server;

        /// <summary>
        /// 当前 <see cref="ApiEventHandler"/> 的 <see cref="EventSource"/> 列表
        /// </summary>
        private ImmutableList<EventSource> EventSources = ImmutableList<EventSource>.Empty;

        /// <summary>
        /// 异步处理通过 Websocket 获取的消息
        /// </summary>
        /// <param name="message">通过 Websocket 获取的消息</param>
        private async Task EventHandlingAsync(string message)
        {
            var info = JsonConvert.DeserializeObject<EventInfo>(message);

            var task = info.Type switch
            {
                "FriendMessage" => FriendMessageEventHandling(message),
                "GroupMessage" => GroupMessageEventHandling(message),
                "TempMessage" => MemberMessageEventHandling(message),
                "BotOnlineEvent" => BotOnlineEvent(message),
                "BotReloginEvent" => BotReloginEvent(message),
                _ => Task.Delay(0)
            };

            await task;
        }

        /// <summary>
        /// 异步调用 <see cref="EventSource"/> 实例的方法
        /// </summary>
        /// <typeparam name="TEventSource">事件源类型</typeparam>
        /// <param name="action">调用所执行操作</param>
        private async Task InvokeAsync<TEventSource>(Action<TEventSource> action)
            where TEventSource : EventSource
        {
            var sources = EventSources.OfType<TEventSource>();

            foreach (var source in sources)
            {
                await Task.Run(() => action.Invoke(source));
            }
        }

        /// <summary>
        /// 绑定指定 <see cref="EventSource"/> 实例
        /// </summary>
        /// <param name="source">将要绑定的 <see cref="EventSource"/> 实例</param>
        public void Bind(params EventSource[] source) => EventSources = ImmutableList.Create(source);

        /// <summary>
        /// 异步监听 Websocket
        /// </summary>
        public async Task ListenAsync()
        {
            Server = new WebSocket(Session.WebsocketUri + "all?sessionKey=" + Session.SessionKey);
            Server.OnMessage += async (sender, e) => await EventHandlingAsync(e.Data);
            await Task.Run(Server.Connect);
        }

        public async ValueTask DisposeAsync()
        {
            foreach (var source in EventSources)
            {
                source.RemoveAllHandlers();
            }

            await Task.Run(Server.Close);
        }

        /// <summary>
        /// 创建 <see cref="ApiEventHandler"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="ApiEventHandler"/> 实例所使用的会话</param>
        internal ApiEventHandler(Session session) : base(session)
        {
        }
    }
}