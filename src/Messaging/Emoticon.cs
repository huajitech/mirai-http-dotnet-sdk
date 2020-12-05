using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http.Messaging
{
    /// <summary>
    /// 表示表情的 <see cref="MessageElement"/>
    /// </summary>
    public class Emoticon : MessageElement
    {
        internal override string Type { get; } = "Face";

        /// <summary>
        /// 获取当前 <see cref="Emoticon"/> 实例的 ID
        /// </summary>
        [JsonProperty(PropertyName = "faceId", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; }

        /// <summary>
        /// 获取当前 <see cref="Emoticon"/> 实例的名称
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; }

        /// <summary>
        /// 创建 <see cref="Emoticon"/> 实例
        /// </summary>
        public Emoticon()
        {
        }

        /// <summary>
        /// 创建 <see cref="Emoticon"/> 实例
        /// </summary>
        /// <param name="id">指定 <see cref="Emoticon"/> 实例的 ID</param>
        public Emoticon(int id) => Id = id;

        /// <summary>
        /// 创建 <see cref="Emoticon"/> 实例
        /// </summary>
        /// <param name="name">指定 <see cref="Emoticon"/> 实例的名称</param>
        public Emoticon(string name) => Name = name;

        /// <summary>
        /// 创建 <see cref="Emoticon"/> 实例
        /// </summary>
        /// <param name="id">指定 <see cref="Emoticon"/> 实例的 ID</param>
        /// <param name="name">指定 <see cref="Emoticon"/> 实例的名称</param>
        public Emoticon(int? id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}