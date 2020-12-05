using HuajiTech.Mirai.Http.Events;
using HuajiTech.Mirai.Http.Interop;
using Newtonsoft.Json;
using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using WebSocketSharp;

namespace HuajiTech.Mirai.Http.ApiHandlers
{
    /// <summary>
    /// 用作与 API 通过 Websocket 交互
    /// </summary>
    public sealed partial class ApiEventHandler : SessionProcessor, IAsyncDisposable
    {
        /// <summary>
        /// 当前 <see cref="ApiEventHandler"/> 的 <see cref="WebSocket"/> 实例
        /// </summary>
        private WebSocket Server;

        /// <summary>
        /// 当前 <see cref="ApiEventHandler"/> 的 <see cref="IEventSource"/> 列表
        /// </summary>
        private ImmutableList<IEventSource> EventSources = ImmutableList<IEventSource>.Empty;

        /// <summary>
        /// 异步处理通过 Websocket 获取的数据
        /// </summary>
        /// <param name="data">通过 Websocket 获取的数据</param>
        private async Task EventHandlingAsync(string data)
        {
            var info = JsonConvert.DeserializeObject<EventData>(data);

            foreach (var eventSource in EventSources)
            {
                if (info.Type == eventSource.Type)
                {
                    await eventSource.InvokeAsync(data, Session);
                }
            }
        }

        /// <summary>
        /// 绑定指定 <see cref="IEventSource"/> 实例
        /// </summary>
        /// <param name="source">将要绑定的 <see cref="IEventSource"/> 实例</param>
        public void Bind(params IEventSource[] source) => EventSources = ImmutableList.Create(source);

        /// <summary>
        /// 异步监听 Websocket
        /// </summary>
        public async Task ListenAsync()
        {
            Server = new(Session.Settings.WebsocketUri + "all?sessionKey=" + Session.SessionKey);
            Server.OnMessage += async (sender, e) => await EventHandlingAsync(e.Data);
            await Task.Run(Server.Connect);
        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            foreach (var source in EventSources)
            {
                source.RemoveAllHandlers();
            }

            if (Server != null)
            {
                await Task.Run(Server.Close);
            }
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