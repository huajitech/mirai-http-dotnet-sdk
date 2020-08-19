using HuajiTech.Mirai.ApiHandlers;
using HuajiTech.Mirai.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义 Session
    /// </summary>
    public class Session : IAsyncDisposable
    {
        /// <summary>
        /// 获取当前 <see cref="Session"/> 实例的 Session Key
        /// </summary>
        internal string SessionKey { get; private set; }

        /// <summary>
        /// 获取当前 <see cref="Session"/> 实例的设置
        /// </summary>
        internal SessionSettings Settings { get; }

        /// <summary>
        /// 获取当前 <see cref="Session"/> 实例的 HTTP URI
        /// </summary>
        internal string HttpUri => Settings.HttpUri;

        /// <summary>
        /// 获取当前 <see cref="Session"/> 实例的 Websocket URI
        /// </summary>
        internal string WebsocketUri => Settings.WebsocketUri;

        /// <summary>
        /// 获取当前 <see cref="Session"/> 实例的机器人号码
        /// </summary>
        internal long BotNumber => Settings.BotNumber;

        /// <summary>
        /// 异步释放 <see cref="Session"/> 实例
        /// </summary>
        public async Task ReleaseAsync() => JObject.Parse(await ApiMethods.ReleaseAsync(HttpUri, SessionKey, BotNumber)).CheckError();

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
            var authResult = JObject.Parse(await ApiMethods.AuthAsync(HttpUri, Settings.AuthKey)).CheckError();
            SessionKey = authResult.Value<string>("session");
        }

        /// <summary>
        /// 异步检验 <see cref="Session"/> 实例
        /// </summary>
        private async Task VerifyAsync() => JObject.Parse(await ApiMethods.VerifyAsync(HttpUri, SessionKey, BotNumber)).CheckError();

        public ValueTask DisposeAsync() => new ValueTask(ReleaseAsync());

        /// <summary>
        /// 创建 <see cref="Session"/> 实例
        /// </summary>
        /// <param name="settings">指定 <see cref="Session"/> 实例所使用的设置</param>
        public Session(SessionSettings settings) => Settings = settings;
    }
}