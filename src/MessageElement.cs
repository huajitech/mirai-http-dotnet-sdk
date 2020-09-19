using HuajiTech.Mirai.Messaging;
using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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
        [JsonProperty(PropertyName = "type")]
        internal abstract string Type { get; }

        /// <inheritdoc/>
        public override string ToString() => TypeStringUtilities.ToTypeString(this);

        /// <inheritdoc/>
        public static implicit operator MessageElement(string str) => new PlainText(str);

        /// <inheritdoc/>
        public static List<MessageElement> operator +(MessageElement left, MessageElement right) => new List<MessageElement>() { left, right };

        /// <inheritdoc/>
        public static List<MessageElement> operator +(List<MessageElement> left, MessageElement right)
        {
            var list = left.ToList();
            list.Add(right);
            return list;
        }

        /// <inheritdoc/>
        public static List<MessageElement> operator +(MessageElement left, List<MessageElement> right)
        {
            var list = right.ToList();
            list.Insert(0, left);
            return list;
        }
    }
}