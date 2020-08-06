using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    public class Session
    {
        internal string SessionKey { get; private set; }

        internal SessionSettings Settings { get; }

        public async Task BindAsync(Plugin plugin)
        {
            plugin.SetCurrentSession(this);
            await plugin.Initialize();
        }

        public async Task ReleaseAsync() => JObject.Parse(await HttpSessions.Release(Settings.Uri, SessionKey, Settings.BotNumber)).CheckError();

        public async Task ConnectAsync()
        {
            await Auth();
            await Verify();
        }

        private async Task Auth()
        {
            var authResult = JObject.Parse(await HttpSessions.Auth(Settings.Uri, Settings.AuthKey)).CheckError();
            SessionKey = authResult.Value<string>("session");
        }

        private async Task Verify() => JObject.Parse(await HttpSessions.Verify(Settings.Uri, SessionKey, Settings.BotNumber)).CheckError();

        public Session(SessionSettings settings) => Settings = settings;
    }
}