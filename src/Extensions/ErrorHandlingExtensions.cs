using HuajiTech.Mirai.Http.Interop;
using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 定义错误处理的扩展方法
    /// </summary>
    internal static class ErrorHandlingExtensions
    {
        /// <summary>
        /// 通过请求返回的 Json 结果检查是否出错
        /// </summary>
        /// <param name="result">Json 结果</param>
        public static string CheckError(this string result)
        {
            var info = JsonConvert.DeserializeObject<ErrorInfo>(result);
            return info.ErrorCode == 0 ? result : throw new ApiException(info.Message, info.ErrorCode);
        }
    }
}