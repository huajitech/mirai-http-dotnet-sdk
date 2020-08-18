using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    internal static partial class ApiMethods
    {
        /// <summary>
        /// 异步认证
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="authKey">AuthKey</param>
        public static async Task<string> AuthAsync(string uri, string authKey) => await HttpUtilities.PostAsync(uri + "auth", JsonConvert.SerializeObject(new { authKey }));

        /// <summary>
        /// 异步校验 Session
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="qq">机器人号码</param>
        public static async Task<string> VerifyAsync(string uri, string sessionKey, long qq) => await HttpUtilities.PostAsync(uri + "verify", JsonConvert.SerializeObject(new { sessionKey, qq }));

        /// <summary>
        /// 异步释放 Session
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="qq">机器人号码</param>
        public static async Task<string> ReleaseAsync(string uri, string sessionKey, long qq) => await HttpUtilities.PostAsync(uri + "release", JsonConvert.SerializeObject(new { sessionKey, qq }));
    }
}