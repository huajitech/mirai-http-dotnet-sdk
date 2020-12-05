using System;

namespace HuajiTech.Mirai.Http.Messaging
{
    /// <summary>
    /// 表示闪图的 <see cref="MessageElement"/>
    /// </summary>
    public class FlashImage : ImageBase
    {
        internal override string Type { get; } = "FlashImage";

        /// <summary>
        /// 创建 <see cref="FlashImage"/> 实例
        /// </summary>
        /// <param name="id">指定 <see cref="FlashImage"/> 实例的 ID</param>
        public FlashImage(string id) : base(id)
        {
        }

        /// <summary>
        /// 创建 <see cref="FlashImage"/> 实例
        /// </summary>
        /// <param name="uri">指定 <see cref="FlashImage"/> 实例的 URI</param>
        public FlashImage(Uri uri) : base(uri)
        {
        }

        /// <summary>
        /// 创建 <see cref="FlashImage"/> 实例
        /// </summary>
        /// <param name="str">指定 <see cref="FlashImage"/> 实例的字符串（可为 ID、字符串形式的 URI、相对文件路径）</param>
        /// <param name="source">指定 <see cref="FlashImage"/> 实例的来源</param>
        public FlashImage(string str, ElementSource source) : base(str, source)
        {
        }

        /// <summary>
        /// 创建 <see cref="FlashImage"/> 实例
        /// </summary>
        /// <param name="id">指定 <see cref="FlashImage"/> 实例的 ID</param>
        /// <param name="filePath">指定 <see cref="FlashImage"/> 实例的相对路径</param>
        /// <param name="uri">指定 <see cref="FlashImage"/> 实例的 URI</param>
        public FlashImage(string id, string filePath, Uri uri) : base(id, filePath, uri)
        {
        }
    }
}