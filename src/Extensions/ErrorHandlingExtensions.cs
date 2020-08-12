using Newtonsoft.Json.Linq;

namespace HuajiTech.Mirai.Extensions
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
        public static JObject CheckError(this JObject result)
        {
            int code = result.Value<int>("code");
            return code == 0 ? result : throw new ApiException(result.Value<string>("msg"), code);
        }
    }
}