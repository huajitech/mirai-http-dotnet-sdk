using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.Messaging
{
    /// <summary>
    /// 表示 App 的 <see cref="MessageElement"/>
    /// </summary>
    public class App : MessageElement
    {
        /// <inheritdoc/>
        protected override string Type { get; } = "App";

        /// <summary>
        /// 获取当前 <see cref="App"/> 实例的内容
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public string Content { get; }

        /// <summary>
        /// 创建 <see cref="App"/> 实例
        /// </summary>
        /// <param name="content">指定 <see cref="App"/> 实例的内容</param>
        public App(string content) => Content = content;
    }
}