using HuajiTech.Mirai.Http.Events;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.ApiHandlers
{
    public partial class ApiEventHandler
    {
        /// <summary>
        /// 处理机器人登录事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private Task BotOnlineEvent(string data) => InvokeAsync<BotEventSource>(x => x.OnBotLogined(Session, JsonConvert.DeserializeObject<BotEventArgs>(data)));

        /// <summary>
        /// 处理机器人重新登录事件
        /// </summary>
        /// <param name="data">事件数据</param>
        private Task BotReloginEvent(string data) => InvokeAsync<BotEventSource>(x => x.OnBotRelogined(Session, JsonConvert.DeserializeObject<BotEventArgs>(data)));
    }
}