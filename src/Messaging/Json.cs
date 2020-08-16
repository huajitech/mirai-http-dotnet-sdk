using Newtonsoft.Json;

namespace HuajiTech.Mirai.Messaging
{
    /// <summary>
    /// 表示 Json 的 <see cref="MessageElement"/>
    /// </summary>
    public class Json : MessageElement
    {
        internal override string Type { get; } = "Json";

        /// <summary>
        /// 获取当前 <see cref="Json"/> 实例的内容
        /// </summary>
        [JsonProperty(PropertyName = "json")]
        public string Content { get; }

        /// <summary>
        /// 创建 <see cref="Json"/> 实例
        /// </summary>
        /// <param name="content">指定 <see cref="Json"/> 实例的内容</param>
        public Json(string content) => Content = content;
    }
}