using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    internal static partial class HttpSessions
    {
        public static async Task<string> GetConfig(Uri uri, string sessionKey) => await HttpUtilities.GetAsync(uri.AbsoluteUri + "config?sessionKey=" + sessionKey);

        public static async Task<string> Config(Uri uri, string sessionKey, bool enableWebsocket) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "config", JsonConvert.SerializeObject(new { sessionKey, enableWebsocket }));

        public static async Task<string> Config(Uri uri, string sessionKey, int cacheSize) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "config", JsonConvert.SerializeObject(new { sessionKey, cacheSize }));

        public static async Task<string> Config(Uri uri, string sessionKey, int cacheSize, bool enableWebsocket) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "config", JsonConvert.SerializeObject(new { sessionKey, cacheSize, enableWebsocket }));
    }
}