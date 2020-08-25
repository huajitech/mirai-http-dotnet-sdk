using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    internal static partial class ApiMethods
    {
        /// <summary>
        /// 异步发送好友消息
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标号码</param>
        /// <param name="messageChain">消息链</param>
        public static Task<string> SendFriendMessageAsync(string uri, string sessionKey, long target, MessageElement[] messageChain) => HttpUtilities.PostAsync(uri + "sendFriendMessage", JsonConvert.SerializeObject(new { sessionKey, target, messageChain }));

        /// <summary>
        /// 异步发送好友消息
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="qq">目标用户号码</param>
        /// <param name="group">目标群号码</param>
        /// <param name="messageChain">消息链</param>
        public static Task<string> SendTempMessageAsync(string uri, string sessionKey, long qq, long group, MessageElement[] messageChain) => HttpUtilities.PostAsync(uri + "sendTempMessage", JsonConvert.SerializeObject(new { sessionKey, qq, group, messageChain }));

        /// <summary>
        /// 异步发送好友消息
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标号码</param>
        /// <param name="messageChain">消息链</param>
        public static Task<string> SendGroupMessageAsync(string uri, string sessionKey, long target, MessageElement[] messageChain) => HttpUtilities.PostAsync(uri + "sendGroupMessage", JsonConvert.SerializeObject(new { sessionKey, target, messageChain }));

        /// <summary>
        /// 异步撤回消息
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="target">目标消息 ID</param>
        public static Task<string> RecallAsync(string uri, string sessionKey, int target) => HttpUtilities.PostAsync(uri + "recall", JsonConvert.SerializeObject(new { sessionKey, target }));

        /// <summary>
        /// 异步撤回消息
        /// </summary>
        /// <param name="uri">API URI</param>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="id">目标消息 ID</param>
        public static Task<string> GetMessageAsync(string uri, string sessionKey, int id) => HttpUtilities.GetAsync($"{uri}messageFromId?sessionKey={sessionKey}&id={id}");
    }
}