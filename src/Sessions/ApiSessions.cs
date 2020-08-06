using HuajiTech.Mirai.Utilities;
using System;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    internal static partial class HttpSessions
    {
        public static async Task<string> About(Uri uri) => await HttpUtilities.GetAsync(uri.AbsoluteUri + "about");
    }
}