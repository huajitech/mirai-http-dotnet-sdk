using HuajiTech.Mirai.Utilities;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    internal static partial class ApiMethods
    {
        /// <summary>
        /// 异步获取好友列表
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        public static async Task<string> GetFriendListAsync(string uri, string sessionKey) => await HttpUtilities.GetAsync(uri + "friendList?sessionKey=" + sessionKey);

        /// <summary>
        /// 异步获取群列表
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        public static async Task<string> GetGroupListAsync(string uri, string sessionKey) => await HttpUtilities.GetAsync(uri + "groupList?sessionKey=" + sessionKey);

        /// <summary>
        /// 异步获取群成员列表
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        public static async Task<string> GetMemberListAsync(string uri, string sessionKey, long target) => await HttpUtilities.GetAsync($"{uri}memberList?sessionKey={sessionKey}&target={target}");
    }
}