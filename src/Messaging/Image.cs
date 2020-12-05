using System;

namespace HuajiTech.Mirai.Http.Messaging
{
    /// <summary>
    /// 表示图片的 <see cref="MessageElement"/>
    /// </summary>
    public class Image : ImageBase
    {
        /// <inheritdoc/>
        protected override string Type { get; } = "Image";

        /// <summary>
        /// 创建 <see cref="Image"/> 实例
        /// </summary>
        /// <param name="id">指定 <see cref="Image"/> 实例的 ID</param>
        public Image(string id) : base(id)
        {
        }

        /// <summary>
        /// 创建 <see cref="Image"/> 实例
        /// </summary>
        /// <param name="uri">指定 <see cref="Image"/> 实例的 URI</param>
        public Image(Uri uri) : base(uri)
        {
        }

        /// <summary>
        /// 创建 <see cref="Image"/> 实例
        /// </summary>
        /// <param name="str">指定 <see cref="Image"/> 实例的字符串（可为 ID、字符串形式的 URI、相对文件路径）</param>
        /// <param name="source">指定 <see cref="Image"/> 实例的来源</param>
        public Image(string str, ElementSource source) : base(str, source)
        {
        }

        /// <summary>
        /// 创建 <see cref="Image"/> 实例
        /// </summary>
        /// <param name="id">指定 <see cref="Image"/> 实例的 ID</param>
        /// <param name="filePath">指定 <see cref="Image"/> 实例的相对路径</param>
        /// <param name="uri">指定 <see cref="Image"/> 实例的 URI</param>
        public Image(string id, string filePath, Uri uri) : base(id, filePath, uri)
        {
        }
    }
}