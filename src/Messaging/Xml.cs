using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.Messaging
{
    /// <summary>
    /// 表示 Xml 的 <see cref="MessageElement"/>
    /// </summary>
    public class Xml : MessageElement
    {
        /// <inheritdoc/>
        protected override string Type { get; } = "Xml";

        /// <summary>
        /// 获取当前 <see cref="Xml"/> 实例的内容
        /// </summary>
        [JsonProperty(PropertyName = "xml")]
        public string Content { get; }

        /// <summary>
        /// 创建 <see cref="Xml"/> 实例
        /// </summary>
        /// <param name="content">指定 <see cref="Xml"/> 实例的内容</param>
        public Xml(string content) => Content = content;
    }
}