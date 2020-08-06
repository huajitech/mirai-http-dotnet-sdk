using HuajiTech.Mirai.Messaging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HuajiTech.Mirai
{
    public abstract class MessageElement
    {
        [JsonProperty(PropertyName = "type")]
        internal abstract string Type { get; }

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