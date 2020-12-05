using HuajiTech.Mirai.Http.Messaging;
using HuajiTech.Mirai.Http.Utilities;
using Newtonsoft.Json;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 表示消息元素
    /// </summary>
    public abstract class MessageElement
    {
        /// <summary>
        /// 指定 <see cref="MessageElement"/> 对应的类型名称
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        protected abstract string Type { get; }

        /// <inheritdoc/>
        public override string ToString() => TypeStringUtilities.ToTypeString(this);

        /// <inheritdoc/>
        public static implicit operator MessageElement(string str) => new PlainText(str);

        /// <inheritdoc/>
        public static ComplexMessage operator +(MessageElement left, MessageElement right) => ComplexMessage.Create(left, right);
    }
}