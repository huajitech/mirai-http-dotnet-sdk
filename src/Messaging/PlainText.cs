using HuajiTech.Mirai.Http.Utilities;
using Newtonsoft.Json;
using System;

namespace HuajiTech.Mirai.Http.Messaging
{
    /// <summary>
    /// 表示纯文本的 <see cref="MessageElement"/>
    /// </summary>
    public class PlainText : MessageElement, IEquatable<PlainText>
    {
        /// <inheritdoc/>
        protected override string Type { get; } = "Plain";

        /// <summary>
        /// 获取当前 <see cref="PlainText"/> 实例的内容
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Content { get; }

        /// <summary>
        /// 表示空 <see cref="PlainText"/>
        /// </summary>
        public static readonly PlainText Empty = new PlainText(string.Empty);

        /// <inheritdoc/>
        public bool Equals(PlainText other) => other != null && other.Content == Content;

        /// <inheritdoc/>
        public override string ToString() => Content;

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as PlainText);

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