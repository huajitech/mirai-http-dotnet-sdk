using HuajiTech.Mirai.ApiHandlers;
using HuajiTech.Mirai.Extensions;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义 Session
    /// </summary>
    public class Session
    {
        /// <summary>
        /// 获取 <see cref="Session"/> 实例的 Session Key
        /// </summary>
        internal string SessionKey { get; private set; }

        /// <summary>
        /// 获取 <see cref="Session"/> 实例的设置
        /// </summary>
        internal SessionSettings Settings { get; }

        /// <summary>
        /// 异步绑定 <see cref="Session"/> 实例到 <see cref="Plugin"/> 实例
        /// </summary>
        /// <param name="plugin">要绑定的 <see cref="Plugin"/> 实例</param>
        public async Task BindAsync(Plugin plugin)
        {
            plugin.SetSession(this);
            await plugin.Initialize();
            var events = new ApiEventHandler(plugin);
            await events.ListenAsync();
        }

        /// <summary>
        /// 异步释放 <see cref="Session"/> 实例
        /// </summary>
        public async Task ReleaseAsync() => JObject.Parse(await ApiMethods.ReleaseAsync(Settings.HttpUri, SessionKey, Settings.BotNumber)).CheckError();

        /// <summary>
        /// 异步连接 <see cref="Session"/> 实例
        /// </summary>
        public async Task ConnectAsync()
        {
            await AuthAsync();
            await VerifyAsync();
        }

        /// <summary>
        /// 异步认证 <see cref="Session"/> 实例
        /// </summary>
        private async Task AuthAsync()
        {
            var authResult = JObject.Parse(await ApiMethods.AuthAsync(Settings.HttpUri, Settings.AuthKey)).CheckError();
            SessionKey = authResult.Value<string>("session");
        }

        /// <summary>
        /// 异步认证 <see cref="Session"/> 实例
        /// </summary>
        private async Task VerifyAsync() => JObject.Parse(await ApiMethods.VerifyAsync(Settings.HttpUri, SessionKey, Settings.BotNumber)).CheckError();

        /// <summary>
        /// 创建 <see cref="Session"/> 实例
        /// </summary>
        /// <param name="settings">指定 <see cref="Session"/> 实例所使用的设置</param>
        public Session(SessionSettings settings) => Settings = settings;
    }
}