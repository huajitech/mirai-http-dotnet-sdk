using HuajiTech.Mirai.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    internal static partial class HttpSessions
    {
        public static async Task<string> GetFriendList(Uri uri, string sessionKey) => await HttpUtilities.GetAsync(uri.AbsoluteUri + "friendList?sessionKey=" + sessionKey);
    }
}