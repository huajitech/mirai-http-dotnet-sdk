using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    internal partial class ApiEventHandler
    {
        private async Task BotOnlineEvent(JObject data) => await Plugin.BotEventSource.OnBotLogined(data.Value<long>("qq"));

        private async Task BotReloginEvent(JObject data) => await Plugin.BotEventSource.OnBotRelogined(data.Value<long>("qq"));
    }
}