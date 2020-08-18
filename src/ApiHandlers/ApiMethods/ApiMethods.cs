using HuajiTech.Mirai.Utilities;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    internal static partial class ApiMethods
    {
        /// <summary>
        /// 异步获取 关于 信息
        /// </summary>
        /// <param name="uri">API URI</param>
        public static async Task<string> GetAboutAsync(string uri) => await HttpUtilities.GetAsync(uri + "about");
    }
}