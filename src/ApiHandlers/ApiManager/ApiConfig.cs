using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.ApiHandlers
{
    /// <summary>
    /// 表示 API 配置
    /// </summary>
    public class ApiConfig
    {
        /// <summary>
        /// 获取对应 <see cref="Session"/> 实例的缓存大小
        /// </summary>
        [JsonProperty(PropertyName = "cacheSize")]
        public int CacheSize { get; internal init; }

        /// <summary>
        /// 获取对应 <see cref="Session"/> 实例是否启用 Websocket
        /// </summary>
        [JsonProperty(PropertyName = "enableWebsocket")]
        public bool WebsocketEnabled { get; internal init; }

        internal ApiConfig()
        {
        }
    }
}