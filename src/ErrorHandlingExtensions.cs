using Newtonsoft.Json.Linq;

namespace HuajiTech.Mirai
{
    internal static class ErrorHandlingExtensions
    {
        public static JObject CheckError(this JObject jObject)
        {
            int code = jObject.Value<int>("code");
            return code == 0 ? jObject : throw new ApiException(string.Format(Resources.UnexpectedReturnValue, code, jObject.Value<string>("msg")), code);
        }
    }
}