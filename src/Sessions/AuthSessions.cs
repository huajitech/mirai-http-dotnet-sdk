using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    internal static partial class HttpSessions
    {
        public static async Task<string> Auth(Uri uri, string authKey) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "auth", JsonConvert.SerializeObject(new { authKey }));

        public static async Task<string> Verify(Uri uri, string sessionKey, long qq) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "verify", JsonConvert.SerializeObject(new { sessionKey, qq }));

        public static async Task<string> Release(Uri uri, string sessionKey, long qq) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "release", JsonConvert.SerializeObject(new { sessionKey, qq }));
    }
}