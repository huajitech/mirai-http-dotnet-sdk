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
        [JsonProperty(PropertyName = "type")]
        internal abstract string Type { get; }

        public override string ToString() => TypeStringUtilities.ToTypeString(this);

        public static implicit operator MessageElement(string str) => new PlainText(str);

        public static List<MessageElement> operator +(MessageElement left, MessageElement right) => new List<MessageElement>() { left, right };

        public static List<MessageElement> operator +(List<MessageElement> left, MessageElement right)
        {
            left.Add(right);
            return left;
        }

        public static List<MessageElement> operator +(MessageElement left, List<MessageElement> right)
        {
            right.Insert(0, left);
            return right;
        }
    }
}