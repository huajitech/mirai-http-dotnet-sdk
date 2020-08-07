using Newtonsoft.Json.Linq;

namespace HuajiTech.Mirai.Extensions
{
    internal static class ErrorHandlingExtensions
    {
        public static JObject CheckError(this JObject result)
        {
            int code = result.Value<int>("code");
            return code == 0 ? result : throw new ApiException(string.Format(Resources.UnexpectedReturnValue, code, result.Value<string>("msg")), code);
        }
    }
}