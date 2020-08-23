using Newtonsoft.Json;
using System;

namespace HuajiTech.Mirai.Events
{
    /// <summary>
    /// 为机器人事件提供数据
    /// </summary>
    public class BotEventArgs : EventArgs
    {
        /// <summary>
        /// 获取当前 <see cref="BotEventArgs"/> 实例的机器人号码
        /// </summary>
        [JsonProperty(PropertyName = "qq")]
        public long Number { get; }

        /// <summary>
        /// 创建 <see cref="BotEventArgs"/> 实例
        /// </summary>
        /// <param name="number">指定 <see cref="BotEventArgs"/> 实例的机器人号码</param>
        public BotEventArgs(long number) => Number = number;
    }
}