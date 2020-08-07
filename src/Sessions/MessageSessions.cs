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

        public static async Task<string> Recall(Uri uri, string sessionKey, int target) => await HttpUtilities.PostAsync(uri.AbsoluteUri + "recall", JsonConvert.SerializeObject(new { sessionKey, target }));

        public static async Task<string> GetMessage(Uri uri, string sessionKey, int id) => await HttpUtilities.GetAsync($"{uri.AbsoluteUri}messageFromId?sessionKey={sessionKey}&id={id}");
    }
}