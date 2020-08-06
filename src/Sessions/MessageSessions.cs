using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    internal static partial class HttpSessions
    {
        public static async Task<string> SendFriendMessage(Uri uri, string sessionKey, long target, MessageElement[] messageChain) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "sendFriendMessage", JsonConvert.SerializeObject(new { sessionKey, target, messageChain }));

        public static async Task<string> SendTempMessage(Uri uri, string sessionKey, long qq, long group, MessageElement[] messageChain) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "sendTempMessage", JsonConvert.SerializeObject(new { sessionKey, qq, group, messageChain }));

        public static async Task<string> SendGroupMessage(Uri uri, string sessionKey, long target, MessageElement[] messageChain) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "sendGroupMessage", JsonConvert.SerializeObject(new { sessionKey, target, messageChain }));
    }
}