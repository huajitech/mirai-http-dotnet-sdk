using HuajiTech.Mirai.Http.ApiHandlers;
using HuajiTech.Mirai.Http.Interop;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 定义 Session
    /// </summary>
    public sealed class Session : IAsyncDisposable
    {
        /// <summary>
        /// 获取当前 <see cref="Session"/> 实例的 Session Key
        /// </summary>
        internal string SessionKey { get; private set; }

        /// <summary>
        /// 获取当前 <see cref="Session"/> 实例的设置
        /// </summary>
        public SessionSettings Settings { get; }

        /// <summary>
        /// 获取当前 <see cref="Session"/> 实例的当前用户
        /// </summary>
        public CurrentUser CurrentUser { get; }

        /// <summary>
        /// 获取当前 <see cref="Session"/> 实例的 API 事件处理器
        /// </summary>
        public ApiEventHandler ApiEventHandler { get; }

        /// <summary>
        /// 获取当前 <see cref="Session"/> 实例的 API 管理器
        /// </summary>
        public ApiManager ApiManager { get; }

        /// <summary>
        /// 获取当前 <see cref="Session"/> 实例的机器人号码
        /// </summary>
        public long BotNumber { get; }

        /// <summary>
        /// 当前 <see cref="Session"/> 实例是否已认证
        /// </summary>
        private bool IsVerified = false;

        /// <summary>
        /// 异步释放 <see cref="Session"/> 实例
        /// </summary>
        public async Task ReleaseAsync() => (await ApiMethods.ReleaseAsync(Settings.HttpUri, SessionKey, BotNumber)).CheckError();

        /// <summary>
        /// 异步连接 <see cref="Session"/> 实例
        /// </summary>
        public async Task ConnectAsync()
        {
            await AuthAsync();
            await VerifyAsync();
            await CurrentUser.GetFriendListAsync(true);
        }

        /// <summary>
        /// 异步认证 <see cref="Session"/> 实例
        /// </summary>
        private async Task AuthAsync()
        {
            var info = JsonConvert.DeserializeObject<AuthInfo>((await ApiMethods.AuthAsync(Settings.HttpUri, Settings.AuthKey)).CheckError());
            SessionKey = info.SessionKey;
        }

        /// <summary>
        /// 异步检验 <see cref="Session"/> 实例
        /// </summary>
        private async Task VerifyAsync()
        {
            (await ApiMethods.VerifyAsync(Settings.HttpUri, SessionKey, BotNumber)).CheckError();
            IsVerified = true;
        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            await ApiEventHandler.DisposeAsync();

            if (SessionKey != null && IsVerified)
            {
                await ReleaseAsync();
            }
        }

        /// <summary>
        /// 创建 <see cref="Session"/> 实例
        /// </summary>
        /// <param name="settings">指定 <see cref="Session"/> 实例所使用的设置</param>
        /// <param name="number">指定 <see cref="Session"/> 实例的机器人号码</param>
        public Session(SessionSettings settings, long number)
        {
            Settings = settings;
            BotNumber = number;
            CurrentUser = new(this);
            ApiEventHandler = new(this);
            ApiManager = new(this);
        }
    }
}