using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    internal static partial class ApiMethods
    {
        /// <summary>
        /// 异步获取 Session 配置
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        public static async Task<string> GetConfigAsync(Uri uri, string sessionKey) => await HttpUtilities.GetAsync(uri.AbsoluteUri + "config?sessionKey=" + sessionKey);

        /// <summary>
        /// 异步配置 Session
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="enableWebsocket">是否启用 Websocket</param>
        public static async Task<string> ConfigAsync(Uri uri, string sessionKey, bool enableWebsocket) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "config", JsonConvert.SerializeObject(new { sessionKey, enableWebsocket }));

        /// <summary>
        /// 异步配置 Session
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="cacheSize">缓存大小</param>
        public static async Task<string> ConfigAsync(Uri uri, string sessionKey, int cacheSize) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "config", JsonConvert.SerializeObject(new { sessionKey, cacheSize }));

        /// <summary>
        /// 异步配置 Session
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="cacheSize">缓存大小</param>
        /// <param name="enableWebsocket">是否启用 Websocket</param>
        public static async Task<string> ConfigAsync(Uri uri, string sessionKey, int cacheSize, bool enableWebsocket) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "config", JsonConvert.SerializeObject(new { sessionKey, cacheSize, enableWebsocket }));
    }
}