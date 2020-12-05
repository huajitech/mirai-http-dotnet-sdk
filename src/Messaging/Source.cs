using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.Messaging
{
    /// <summary>
    /// 表示来源的 <see cref="MessageElement"/>
    /// </summary>
    internal class Source : MessageElement
    {
        protected override string Type { get; } = "Source";

        /// <summary>
        /// 获取当前 <see cref="Source"/> 实例的 ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; }

        /// <summary>
        /// 获取当前 <see cref="Source"/> 实例的时间戳
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public int Time { get; }

        /// <summary>
        /// 创建 <see cref="Source"/> 实例
        /// </summary>
        /// <param name="id">指定 <see cref="Source"/> 实例的 ID</param>
        /// <param name="time">指定 <see cref="Source"/> 实例的时间戳</param>
        public Source(int id, int time)
        {
            Id = id;
            Time = time;
        }
    }
}