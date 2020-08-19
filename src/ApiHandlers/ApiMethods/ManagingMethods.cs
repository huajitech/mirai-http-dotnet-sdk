using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json;
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

        /// <summary>
        /// 异步群全员禁言
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        public static async Task<string> MuteAllAsync(string uri, string sessionKey, long target) => await HttpUtilities.PostAsync(uri + "muteAll", JsonConvert.SerializeObject(new { sessionKey, target }));

        /// <summary>
        /// 异步解除群全员禁言
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        public static async Task<string> UnmuteAllAsync(string uri, string sessionKey, long target) => await HttpUtilities.PostAsync(uri + "unmuteAll", JsonConvert.SerializeObject(new { sessionKey, target }));

        /// <summary>
        /// 异步禁言群成员
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        /// <param name="memberId">目标成员号码</param>
        /// <param name="time">禁言时长</param>
        public static async Task<string> MuteAsync(string uri, string sessionKey, long target, long memberId, int time) => await HttpUtilities.PostAsync(uri + "mute", JsonConvert.SerializeObject(new { sessionKey, target, memberId, time }));

        /// <summary>
        /// 异步禁言群成员
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        /// <param name="memberId">目标成员号码</param>
        public static async Task<string> UnmuteAsync(string uri, string sessionKey, long target, long memberId) => await HttpUtilities.PostAsync(uri + "unmute", JsonConvert.SerializeObject(new { sessionKey, target, memberId }));

        /// <summary>
        /// 异步移除群成员
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        /// <param name="memberId">目标成员号码</param>
        /// <param name="msg">移除消息</param>
        public static async Task<string> KickAsync(string uri, string sessionKey, long target, long memberId, string msg = null) => await HttpUtilities.PostAsync(uri + "kick", JsonConvert.SerializeObject(new { sessionKey, target, memberId, msg }));

        /// <summary>
        /// 异步移除群成员
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        public static async Task<string> QuitAsync(string uri, string sessionKey, long target) => await HttpUtilities.PostAsync(uri + "quit", JsonConvert.SerializeObject(new { sessionKey, target }));

        /// <summary>
        /// 异步获取群成员信息
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        /// <param name="memberId">目标成员号码</param>
        public static async Task<string> GetMemberInfo(string uri, string sessionKey, long target, long memberId) => await HttpUtilities.GetAsync($"{uri}/memberInfo?sessionKey={sessionKey}&target={target}&memberId={memberId}");
    }
}