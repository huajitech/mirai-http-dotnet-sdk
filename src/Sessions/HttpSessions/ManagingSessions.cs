using HuajiTech.Mirai.Utilities;
using System;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    internal static partial class HttpSessions
    {
        /// <summary>
        /// 异步获取好友列表
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        public static async Task<string> GetFriendListAsync(Uri uri, string sessionKey) => await HttpUtilities.GetAsync(uri.AbsoluteUri + "friendList?sessionKey=" + sessionKey);

        /// <summary>
        /// 异步获取群列表
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        public static async Task<string> GetGroupListAsync(Uri uri, string sessionKey) => await HttpUtilities.GetAsync(uri.AbsoluteUri + "groupList?sessionKey=" + sessionKey);

        /// <summary>
        /// 异步获取群成员列表
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        public static async Task<string> GetMemberListAsync(Uri uri, string sessionKey, long target) => await HttpUtilities.GetAsync($"{uri.AbsoluteUri}memberList?sessionKey={sessionKey}&target={target}");
    }
}