using HuajiTech.Mirai.Http.Utilities;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.Http.ApiHandlers
{
    internal static partial class ApiMethods
    {
        /// <summary>
        /// 异步获取 关于 信息
        /// </summary>
        /// <param name="uri">API URI</param>
        public static Task<string> GetAboutAsync(string uri) => ApiHttpUtilities.GetAsync($"{uri}about");
    }
}