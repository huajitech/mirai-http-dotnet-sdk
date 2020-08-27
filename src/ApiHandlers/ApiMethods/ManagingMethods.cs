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
        public static Task<string> GetFriendListAsync(string uri, string sessionKey) => HttpUtilities.GetAsync(uri + "friendList?sessionKey=" + sessionKey);

        /// <summary>
        /// 异步获取群列表
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        public static Task<string> GetGroupListAsync(string uri, string sessionKey) => HttpUtilities.GetAsync(uri + "groupList?sessionKey=" + sessionKey);

        /// <summary>
        /// 异步获取群成员列表
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        public static Task<string> GetMemberListAsync(string uri, string sessionKey, long target) => HttpUtilities.GetAsync($"{uri}memberList?sessionKey={sessionKey}&target={target}");

        /// <summary>
        /// 异步群全员禁言
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        public static Task<string> MuteAllAsync(string uri, string sessionKey, long target) => HttpUtilities.PostAsync(uri + "muteAll", JsonConvert.SerializeObject(new { sessionKey, target }));

        /// <summary>
        /// 异步解除群全员禁言
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        public static Task<string> UnmuteAllAsync(string uri, string sessionKey, long target) => HttpUtilities.PostAsync(uri + "unmuteAll", JsonConvert.SerializeObject(new { sessionKey, target }));

        /// <summary>
        /// 异步禁言群成员
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        /// <param name="memberId">目标成员号码</param>
        /// <param name="time">禁言时长</param>
        public static Task<string> MuteAsync(string uri, string sessionKey, long target, long memberId, int time) => HttpUtilities.PostAsync(uri + "mute", JsonConvert.SerializeObject(new { sessionKey, target, memberId, time }));

        /// <summary>
        /// 异步禁言群成员
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        /// <param name="memberId">目标成员号码</param>
        public static Task<string> UnmuteAsync(string uri, string sessionKey, long target, long memberId) => HttpUtilities.PostAsync(uri + "unmute", JsonConvert.SerializeObject(new { sessionKey, target, memberId }));

        /// <summary>
        /// 异步移除群成员
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        /// <param name="memberId">目标成员号码</param>
        /// <param name="msg">移除消息</param>
        public static Task<string> KickAsync(string uri, string sessionKey, long target, long memberId, string msg = null) => HttpUtilities.PostAsync(uri + "kick", JsonConvert.SerializeObject(new { sessionKey, target, memberId, msg }));

        /// <summary>
        /// 异步移除群成员
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        public static Task<string> QuitAsync(string uri, string sessionKey, long target) => HttpUtilities.PostAsync(uri + "quit", JsonConvert.SerializeObject(new { sessionKey, target }));

        /// <summary>
        /// 异步获取群成员信息
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        /// <param name="memberId">目标成员号码</param>
        public static Task<string> GetMemberInfo(string uri, string sessionKey, long target, long memberId) => HttpUtilities.GetAsync($"{uri}memberInfo?sessionKey={sessionKey}&target={target}&memberId={memberId}");

        /// <summary>
        /// 异步获取群设置
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        public static Task<string> GetGroupConfig(string uri, string sessionKey, long target) => HttpUtilities.GetAsync($"{uri}groupConfig?sessionKey={sessionKey}&target={target}");

        /// <summary>
        /// 异步修改群设置
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        /// <param name="config">配置</param>
        public static Task<string> GroupConfig(string uri, string sessionKey, long target, object config) => HttpUtilities.PostAsync(uri + "groupConfig", JsonConvert.SerializeObject(new { sessionKey, target, config }));

        /// <summary>
        /// 异步修改群设置
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标群号码</param>
        /// <param name="memberId">目标成员号码</param>
        /// <param name="config">配置</param>
        public static Task<string> MemberConfig(string uri, string sessionKey, long target, long memberId, object config) => HttpUtilities.PostAsync(uri + "groupConfig", JsonConvert.SerializeObject(new { sessionKey, target, memberId, config }));
    }
}