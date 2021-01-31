using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.ApiHandlers
{
    /// <summary>
    /// 表示 API 信息
    /// </summary>
    public class ApiInfo
    {
        /// <summary>
        /// API 版本
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; internal set; }

        internal ApiInfo()
        {
        }
    }
}