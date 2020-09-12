using HuajiTech.Mirai.Utilities;
using Newtonsoft.Json;

namespace HuajiTech.Mirai.Messaging
{
    /// <summary>
    /// 表示纯文本的 <see cref="MessageElement"/>
    /// </summary>
    public class PlainText : MessageElement
    {
        internal override string Type { get; } = "Plain";

        /// <summary>
        /// 获取当前 <see cref="PlainText"/> 实例的内容
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Content { get; }

        /// <inheritdoc/>
        public override string ToString() => Content;

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is PlainText plainText ? plainText.Content == Content : obj as string == Content;

        /// <inheritdoc/>
        public override int GetHashCode() => base.GetHashCode();

        /// <inheritdoc/>
        public static implicit operator string(PlainText plainText) => plainText.Content ?? string.Empty;

        /// <inheritdoc/>
        public static bool operator ==(PlainText left, PlainText right) => left?.Equals(right) ?? NullableUtilities.NullEquals(left, right);

        /// <inheritdoc/>
        public static bool operator !=(PlainText left, PlainText right) => !(left?.Equals(right) ?? NullableUtilities.NullEquals(left, right));

        /// <summary>
        /// 创建 <see cref="PlainText"/> 实例
        /// </summary>
        /// <param name="content">指定 <see cref="PlainText"/> 实例的内容</param>
        public PlainText(string content) => Content = content;
    }
}