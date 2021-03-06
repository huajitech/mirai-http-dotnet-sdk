﻿using HuajiTech.Mirai.Http.Utilities;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.ApiHandlers
{
    internal static partial class ApiMethods
    {
        /// <summary>
        /// 异步获取 Session 配置
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        public static Task<string> GetConfigAsync(string uri, string sessionKey) => ApiHttpUtilities.GetAsync($"{uri}config?sessionKey={sessionKey}");

        /// <summary>
        /// 异步配置 Session
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="enableWebsocket">是否启用 Websocket</param>
        public static Task<string> ConfigAsync(string uri, string sessionKey, bool enableWebsocket) => ApiHttpUtilities.PostAsync($"{uri}config", JsonConvert.SerializeObject(new { sessionKey, enableWebsocket }));

        /// <summary>
        /// 异步配置 Session
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="cacheSize">缓存大小</param>
        public static Task<string> ConfigAsync(string uri, string sessionKey, int cacheSize) => ApiHttpUtilities.PostAsync($"{uri}config", JsonConvert.SerializeObject(new { sessionKey, cacheSize }));

        /// <summary>
        /// 异步配置 Session
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="cacheSize">缓存大小</param>
        /// <param name="enableWebsocket">是否启用 Websocket</param>
        public static Task<string> ConfigAsync(string uri, string sessionKey, int cacheSize, bool enableWebsocket) => ApiHttpUtilities.PostAsync($"{uri}config", JsonConvert.SerializeObject(new { sessionKey, cacheSize, enableWebsocket }));
    }
}