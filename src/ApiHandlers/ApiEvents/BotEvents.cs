using HuajiTech.Mirai.Events;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    internal partial class ApiEventHandler
    {
        private async Task BotOnlineEvent(string data) => await Plugin.BotEventSource.OnBotLogined(JsonConvert.DeserializeObject<BotEventArgs>(data));

        private async Task BotReloginEvent(string data) => await Plugin.BotEventSource.OnBotRelogined(JsonConvert.DeserializeObject<BotEventArgs>(data));
    }
}