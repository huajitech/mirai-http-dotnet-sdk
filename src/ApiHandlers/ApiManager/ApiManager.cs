using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    /// <summary>
    /// 用作对 API 的管理器
    /// </summary>
    public class ApiManager : SessionProcessor
    {
        /// <summary>
        /// 异步获取 API 信息
        /// </summary>
        public async Task<ApiInfo> GetApiInfoAsync() => JObject.Parse((await ApiMethods.GetAboutAsync(Session.Settings.HttpUri)).CheckError())["data"].ToObject<ApiInfo>();

        /// <summary>
        /// 异步获取对应 <see cref="Session"/> 实例的 API 配置
        /// </summary>
        public async Task<ApiConfig> GetApiConfigAsync() => JsonConvert.DeserializeObject<ApiConfig>(await ApiMethods.GetConfigAsync(Session.Settings.HttpUri, Session.SessionKey));

        /// <summary>
        /// 异步设置对应 <see cref="Session"/> 实例的缓存大小
        /// </summary>
        /// <param name="size">缓存大小</param>
        public async Task SetCacheSizeAsync(int size) => (await ApiMethods.ConfigAsync(Session.Settings.HttpUri, Session.SessionKey, size)).CheckError();

        /// <summary>
        /// 异步设置对应 <see cref="Session"/> 实例的 Websocket
        /// </summary>
        /// <param name="enabled">是否启用</param>
        private async Task SetWebsocketAsync(bool enabled) => (await ApiMethods.ConfigAsync(Session.Settings.HttpUri, Session.SessionKey, enabled)).CheckError();

        /// <summary>
        /// 异步启用对应 <see cref="Session"/> 实例的 Websocket
        /// </summary>
        public Task EnableWebsocketAsync() => SetWebsocketAsync(true);

        /// <summary>
        /// 异步禁用对应 <see cref="Session"/> 实例的 Websocket
        /// </summary>
        public Task DisableWebsocketAsync() => SetWebsocketAsync(false);

        /// <summary>
        /// 创建 <see cref="ApiManager"/> 实例
        /// </summary>
        /// <param name="session">指定 <see cref="ApiManager"/> 实例所使用的 Session</param>
        internal ApiManager(Session session) : base(session)
        {
        }
    }
}