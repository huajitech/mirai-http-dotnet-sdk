using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Sessions
{
    internal static partial class HttpSessions
    {
        /// <summary>
        /// 异步发送好友消息
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标号码</param>
        /// <param name="messageChain">消息链</param>
        public static async Task<string> SendFriendMessageAsync(Uri uri, string sessionKey, long target, MessageElement[] messageChain) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "sendFriendMessage", JsonConvert.SerializeObject(new { sessionKey, target, messageChain }));

        /// <summary>
        /// 异步发送好友消息
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="qq">目标用户号码</param>
        /// <param name="group">目标群号码</param>
        /// <param name="messageChain">消息链</param>
        public static async Task<string> SendTempMessageAsync(Uri uri, string sessionKey, long qq, long group, MessageElement[] messageChain) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "sendTempMessage", JsonConvert.SerializeObject(new { sessionKey, qq, group, messageChain }));

        /// <summary>
        /// 异步发送好友消息
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标号码</param>
        /// <param name="messageChain">消息链</param>
        public static async Task<string> SendGroupMessageAsync(Uri uri, string sessionKey, long target, MessageElement[] messageChain) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "sendGroupMessage", JsonConvert.SerializeObject(new { sessionKey, target, messageChain }));

        /// <summary>
        /// 异步撤回消息
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标消息 ID</param>
        public static async Task<string> RecallAsync(Uri uri, string sessionKey, int target) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "recall", JsonConvert.SerializeObject(new { sessionKey, target }));

        /// <summary>
        /// 异步撤回消息
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="id">目标消息 ID</param>
        public static async Task<string> GetMessageAsync(Uri uri, string sessionKey, int id) => await HttpUtilities.GetAsync($"{uri.AbsoluteUri}messageFromId?sessionKey={sessionKey}&id={id}");
    }
}