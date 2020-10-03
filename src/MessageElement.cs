using HuajiTech.Mirai.Messaging;
using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HuajiTech.Mirai
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
        internal virtual string Type { get; } = null;

        /// <inheritdoc/>
        public override string ToString() => TypeStringUtilities.ToTypeString(this);

        /// <inheritdoc/>
        public static implicit operator MessageElement(string str) => new PlainText(str);

        /// <inheritdoc/>
        public static ComplexMessage operator +(MessageElement left, MessageElement right) => ComplexMessage.Create(left, right);
    }
}