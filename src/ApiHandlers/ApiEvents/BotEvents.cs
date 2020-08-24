using HuajiTech.Mirai.Events;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    public partial class ApiEventHandler
    {
        /// <summary>
        /// 处理机器人登录事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task BotOnlineEvent(string data) => await InvokeAsync<BotEventSource>(async x => await x.OnBotLogined(Session, JsonConvert.DeserializeObject<BotEventArgs>(data)));

        /// <summary>
        /// 处理机器人重新登录事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private async Task BotReloginEvent(string data) => await InvokeAsync<BotEventSource>(async x => await x.OnBotRelogined(Session, JsonConvert.DeserializeObject<BotEventArgs>(data)));
    }
}