﻿using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.Events
{
    /// <summary>
    /// 指定好友消息接收事件源
    /// </summary>
    public class BotReloginedEventSource : EventSource<BotEventArgs>
    {
        /// <inheritdoc/>
        internal override string Type { get; } = "BotReloginEvent";

        /// <inheritdoc/>
        private protected override async Task<BotEventArgs> ToEventArgsAsync(string data, Session session)
        {
            await Task.Delay(0);
            return JsonConvert.DeserializeObject<BotEventArgs>(data);
        }

        /// <summary>
        /// 创建 <see cref="BotReloginedEventSource"/> 实例
        /// </summary>
        public BotReloginedEventSource()
        {
        }
    }
}