using HuajiTech.Mirai.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HuajiTech.Mirai.ApiHandlers
{
    /// <summary>
    /// 提供 API 的管理方法
    /// </summary>
    public static class ApiManager
    {
        /// <summary>
        /// 获取 API 信息
        /// </summary>
        /// <param name="settings">会话设置</param>
        public static async Task<ApiInfo> GetApiInfo(SessionSettings settings) => JObject.Parse((await ApiMethods.GetAboutAsync(settings.HttpUri)).CheckError())["data"].ToObject<ApiInfo>();
    }
}