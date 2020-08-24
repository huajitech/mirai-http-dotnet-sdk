using HuajiTech.Mirai.Events;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    public partial class ApiEventHandler
    {
        private async Task BotOnlineEvent(string data) => await InvokeAsync<BotEventSource>(async x => await x.OnBotLogined(JsonConvert.DeserializeObject<BotEventArgs>(data)));

        private async Task BotReloginEvent(string data) => await InvokeAsync<BotEventSource>(async x => await x.OnBotRelogined(JsonConvert.DeserializeObject<BotEventArgs>(data)));
    }
}