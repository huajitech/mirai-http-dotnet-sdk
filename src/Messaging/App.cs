using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuajiTech.Mirai.Messaging
{
    public class App : MessageElement
    {
        internal override string Type { get; } = "App";

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